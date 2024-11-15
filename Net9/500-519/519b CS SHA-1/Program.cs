// 519b CS SHA-1
// Example of implementation of SHA-1 protocol
// http://en.wikipedia.org/wiki/SHA-1
//
// 2014-03-24   PV
// 2014-03-25   PV      SHA512 & 385; .Net version
// 2017-04-27   PV      SHA-1, VS2017
// 2019-10-15   PV      VS2019
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10   PV      Net7
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using static System.Console;

namespace CS519b;

internal class Program
{
    private static void Main()
    {
        WriteLine("519b CS SHA-1");

        // Test rotation function
        uint u32 = 0xcafe;
        u32 = LeftRotate(u32, 1);
        u32 = LeftRotate(u32, 2);
        u32 = LeftRotate(u32, 4);
        u32 = LeftRotate(u32, 8);
        u32 = LeftRotate(u32, 15);
        u32 = LeftRotate(u32, 29);
        u32 = LeftRotate(u32, 5);
        Debug.Assert(u32 == 0xcafe);

        // For tests, strings are only considered as composed of simple bytes (ASCII), not unicode characters

        // Empty string
        Test_sha1("",
            "da39a3ee5e6b4b0d3255bfef95601890afd80709");

        Test_sha1("The quick brown fox jumps over the lazy dog",
            "2fd4e1c67a2d28fced849ee1bb76e7391b93eb12");

        // Just changing a character completely change the output
        Test_sha1("The quick brown fox jumps over the lazy cog",
            "de9f2c7fd25e1b3afad3e85a0bd17d9b100db4b3");

        WriteLine("All SHA-1 tests passed successfully");
    }

    private static void Test_sha1(string s, string hashed)
    {
        // Use local implementation
        Debug.Assert(SHA1_PV(s) == hashed);

        // Use .Net Framework version
        var bytes = Encoding.UTF8.GetBytes(s);
#pragma warning disable CA5350 // Do Not Use Weak Cryptographic Algorithms
        var hash = SHA1.HashData(bytes);
        StringBuilder hsb = new();
        foreach (var b in hash)
            _ = hsb.Append(b.ToString("x2"));
        Debug.Assert(hsb.ToString() == hashed);
    }

    private static void Preprocessing(string s, int blocksize, int lengthsize, out byte[] tb, out int nb)
    {
        // Pre-processing:
        // append the bit '1' to the message
        // append k bits '0', where k is the minimum number >= 0 such that the resulting message
        // length (modulo <blocksize> in bits) is <blocksize>-<length>.
        // append length of message (without the '1' bit or padding), _in bits_, as 64-bit big-endian integer
        // (this will make the entire post-processed length a multiple of 512 bits)

        var lB = s.Length;      // Message length in Bytes (only process ascii here, one byte per character)
        var lb = 8 * lB;        // Message length in bits
        nb = lb / blocksize;    // Number of blocks of 512 bits
        if (lb == 0 || lb % blocksize != 0)
            nb++;
        if (lb % blocksize >= blocksize - lengthsize)
            nb++;

        tb = new byte[nb * (blocksize / 8)];
        for (var i = 0; i < lB; i++)
            tb[i] = (byte)s[i];
        var j = lB;
        tb[j++] = 0x80;
        while (j % (blocksize / 8) != (blocksize - lengthsize) / 8)
            tb[j++] = 0;
        // Length is always 32-bit in this implementation
        if (lengthsize == 128)
            for (var i = 0; i < 8; i++)
                tb[j++] = 0;

        tb[j++] = 0;
        tb[j++] = 0;
        tb[j++] = 0;
        tb[j++] = 0;
        tb[j++] = (byte)(lb >> 24);
        tb[j++] = (byte)((lb & 0x00FF0000) >> 16);
        tb[j++] = (byte)((lb & 0x0000FF00) >> 8);
        tb[j++] = (byte)(lb & 0x000000FF);
        Debug.Assert(j % (blocksize / 8) == 0);
        Debug.Assert(j == nb * (blocksize / 8));
    }

    // Note 1: All variables are 32 bit unsigned integers and addition is calculated modulo 2^32
    // Note 2: For each round, there is one round constant k[i] and one entry in the message schedule array w[i], 0 ≤ i ≤ 63
    // Note 3: The compression function uses 8 working variables, a through h
    // Note 4: Big-endian convention is used when expressing the constants in this pseudocode,
    // and when parsing message block data from bytes to words, for example,
    // the first word of the input message "abc" after padding is 0x61626380
    private static string SHA1_PV(string s)
    {
        // Initialize hash values h[0..4]
        uint[] h = [
            0x67452301,
            0xEFCDAB89,
            0x98BADCFE,
            0x10325476,
            0xC3D2E1F0
        ];

        // tb: Table of bytes
        // nb: Number of blocks
        Preprocessing(s, 512, 64, out var tb, out var nb);

        // Process the message in successive 512-bit chunks:
        // break message into 512-bit chunks for each chunk

        // br is the bloc rank (number)
        for (var br = 0; br < nb; br++)
        {
            // create a 80-entry message schedule array w[0..79] of 32-bit words
            var w = new uint[80];

            // copy chunk into first 16 words w[0..15] of the message schedule array
            for (var i = 0; i < 64; i += 4)
                w[i >> 2] = (uint)(tb[(br << 6) + i] << 24) + (uint)(tb[(br << 6) + i + 1] << 16) + (uint)(tb[(br << 6) + i + 2] << 8) + tb[(br << 6) + i + 3];

            // Extend the first 16 words into the remaining 64 words w[16..79] of the message schedule array:
            // for i from 16 to 79:
            //     w[i] = (w[i - 3] xor w[i - 8] xor w[i - 14] xor w[i - 16]) leftrotate 1
            for (var i = 16; i < 80; i++)
                w[i] = LeftRotate(w[i - 3] ^ w[i - 8] ^ w[i - 14] ^ w[i - 16], 1);

            // Initialize working variables to current hash value:
            var a = h[0];
            var b = h[1];
            var c = h[2];
            var d = h[3];
            var e = h[4];

            // Compression function main loop:
            // for i from 0 to 79
            for (var i = 0; i < 80; i++)
            {
                //if 0 ≤ i ≤ 19 then
                //    f = (b and c) or ((not b) and d)
                //    k = 0x5A827999
                //else if 20 ≤ i ≤ 39
                //    f = b xor c xor d
                //    k = 0x6ED9EBA1
                //else if 40 ≤ i ≤ 59
                //    f = (b and c) or (b and d) or (c and d)
                //    k = 0x8F1BBCDC
                //else if 60 ≤ i ≤ 79
                //    f = b xor c xor d
                //    k = 0xCA62C1D6
                //
                //temp = (a leftrotate 5) + f + e + k + w[i]
                //e = d
                //d = c
                //c = b leftrotate 30
                //b = a
                //a = temp

                uint f, k;
                if (i <= 19)
                {
                    f = b & c | ~b & d;
                    k = 0x5A827999;
                }
                else if (i <= 39)
                {
                    f = b ^ c ^ d;
                    k = 0x6ED9EBA1;
                }
                else if (i <= 59)
                {
                    f = b & c | b & d | c & d;
                    k = 0x8F1BBCDC;
                }
                else
                {
                    f = b ^ c ^ d;
                    k = 0xCA62C1D6;
                }

                var temp = LeftRotate(a, 5) + f + e + k + w[i];
                e = d;
                d = c;
                c = LeftRotate(b, 30);
                b = a;
                a = temp;
            }

            // Add the compressed chunk to the current hash value:
            h[0] = h[0] + a;
            h[1] = h[1] + b;
            h[2] = h[2] + c;
            h[3] = h[3] + d;
            h[4] = h[4] + e;
        }

        // Produce the final hash value (big-endian) as a 160-bit number:
        // hh = (h0 leftshift 128) or (h1 leftshift 96) or (h2 leftshift 64) or (h3 leftshift 32) or h4
        return h[0].ToString("x8") + h[1].ToString("x8") + h[2].ToString("x8") + h[3].ToString("x8") + h[4].ToString("x8");
    }

    // equivalent of C++ _rotl
    // 32-bit version
    private static uint LeftRotate(uint original, int bits) => original << bits | original >> 32 - bits;
}
