// 519 CS SHA-2
// Example of implementation of SHA-2 protocol
// Notes:
// - This is just to understand SHA-2, not a performance/reference implementation, use .Net provided version for that!
// - Length is only managed in bytes (multiple of 8 bits)
// http://en.wikipedia.org/wiki/SHA-2
//
// 2014-03-24   PV
// 2014-03-25   PV      SHA512 & 385; .Net version
// 2019-10-14   PV      VS2019; Added Go examples "x" and "X"
// 2021-09-26   PV      VS2022; Net6


using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

#pragma warning disable SYSLIB0021 // Type or member is obsolete

namespace SHA_2
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("CS 519 SHA-2");

            // Test rotation function
            uint u32 = 0xcafe;
            u32 = RightRotate(u32, 1);
            u32 = RightRotate(u32, 2);
            u32 = RightRotate(u32, 4);
            u32 = RightRotate(u32, 8);
            u32 = RightRotate(u32, 15);
            u32 = RightRotate(u32, 29);
            u32 = RightRotate(u32, 5);
            Debug.Assert(u32 == 0xcafe);

            ulong u64 = 0xcafe;
            u64 = RightRotate(u64, 4);
            u64 = RightRotate(u64, 1);
            u64 = RightRotate(u64, 12);
            u64 = RightRotate(u64, 37);
            u64 = RightRotate(u64, 10);
            Debug.Assert(u64 == 0xcafe);

            // For tests, strings are only considered as composed of simple bytes (ASCII), not unicode characters

            // Empty string
            Test_sha_256("",
                "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");

            Test_sha_256("The quick brown fox jumps over the lazy dog",
                "d7a8fbb307d7809469ca9abcb0082e4f8d5651e46d3cdb762d02d0bf37c9e592");

            // Just adding a character completely change the output
            Test_sha_256("The quick brown fox jumps over the lazy dog.",
                "ef537f25c895bfa782526529a9b63d97aa631564d5d789c2b765448c8635fb6c");

            // Two blocks processing
            Test_sha_256("abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq",
                "248d6a61d20638b8e5c026930c3e6039a33ce45964ff2167f6ecedd419db06c1");

            // 2019-20-14 Compare with Go
            Test_sha_256("x", "2d711642b726b04401627ca9fbac32f5c8530fb1903cc4db02258717921a4881");
            Test_sha_256("X", "4b68ab3847feda7d6c62c1fbcbeebfa35eab7351ed5e78f4ddadea5df64b8015");

            // Empty string
            Test_sha_512("",
                "cf83e1357eefb8bdf1542850d66d8007d620e4050b5715dc83f4a921d36ce9ce47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e");

            Test_sha_512("abc",
                "ddaf35a193617abacc417349ae20413112e6fa4e89a97ea20a9eeee64b55d39a2192992a274fc1a836ba3c23a3feebbd454d4423643ce80e2a9ac94fa54ca49f");

            Test_sha_512("The quick brown fox jumps over the lazy dog",
                "07e547d9586f6a73f73fbac0435ed76951218fb7d0c8d788a309d785436bbb642e93a252a954f23912547d1e8a3b5ed6e1bfd7097821233fa0538f3db854fee6");

            Test_sha_512("The quick brown fox jumps over the lazy dog.",
                "91ea1245f20d46ae9a037a989f54f1f790f0a47607eeb8a14d12890cea77a1bbc6c7ed9cf205e67b7f2b8fd4c7dfd3a7a8617e45f3c463d481c7e586c39ac1ed");

            // Two blocks processing
            Test_sha_512("abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmnhijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu",
                "8e959b75dae313da8cf4f72814fc143f8f7779c6eb9f7fa17299aeadb6889018501d289e4900f7e4331b99dec4b5433ac7d329eeb6dd26545e96e55b874be909");

            // Empty string
            Test_sha_224("",
                "d14a028c2a3a2bc9476102bb288234c415a2b01f828ea62ac5b3e42f");

            // Empty string
            Test_sha_224("The quick brown fox jumps over the lazy dog",
                "730e109bd7a8a32b1cb9d9a09aa2325d2430587ddbc0c38bad911525");

            // Empty string
            Test_sha_224("The quick brown fox jumps over the lazy dog.",
                "619cba8e8e05826e9b8c519c0a5c68f4fb653e8a3d8aa04bb2c8cd4c");

            // Empty string
            Test_sha_384("",
                "38b060a751ac96384cd9327eb1b1e36a21fdb71114be07434c0cc7bf63f6e1da274edebfe76f65fbd51ad2f14898b95b");

            Test_sha_384("abc",
                "cb00753f45a35e8bb5a03d699ac65007272c32ab0eded1631a8b605a43ff5bed8086072ba1e7cc2358baeca134c825a7");

            Test_sha_384("The quick brown fox jumps over the lazy dog",
                "ca737f1014a48f4c0b6dd43cb177b0afd9e5169367544c494011e3317dbf9a509cb1e5dc1e85a941bbee3d7f2afbc9b1");

            Test_sha_384("The quick brown fox jumps over the lazy dog.",
                "ed892481d8272ca6df370bf706e4d7bc1b5739fa2177aae6c50e946678718fc67a7af2819a021c2fc34e91bdb63409d7");

            Console.WriteLine("All tests passed successfully");
        }

        private static void Test_sha_256(string s, string hashed)
        {
            // Use local implementation
            Debug.Assert(SHA_256(s) == hashed);

            // Use .Net Framework version
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            using SHA256Managed hashstring = new();
            byte[] hash = hashstring.ComputeHash(bytes);
            StringBuilder hsb = new();
            foreach (byte b in hash)
                hsb.Append(b.ToString("x2"));
            Debug.Assert(hsb.ToString() == hashed);
        }

        private static void Test_sha_224(string s, string hashed)
        {
            // Use local implementation
            Debug.Assert(SHA_224(s) == hashed);

            // .Net Framework does not provide a managed version
        }

        private static void Test_sha_512(string s, string hashed)
        {
            // Use local implementation
            Debug.Assert(SHA_512(s) == hashed);

            // Use .Net Framework version
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            using SHA512Managed hashstring = new();
            byte[] hash = hashstring.ComputeHash(bytes);
            StringBuilder hsb = new();
            foreach (byte b in hash)
                hsb.Append(b.ToString("x2"));
            Debug.Assert(hsb.ToString() == hashed);
        }

        private static void Test_sha_384(string s, string hashed)
        {
            // Use local implementation
            Debug.Assert(SHA_384(s) == hashed);

            // Use .Net Framework version
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            using SHA384Managed hashstring = new();
            byte[] hash = hashstring.ComputeHash(bytes);
            StringBuilder hsb = new();
            foreach (byte b in hash)
                hsb.Append(b.ToString("x2"));
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

            int lB = s.Length;      // Message length in Bytes (only process ascii here, one byte per character)
            int lb = 8 * lB;        // Message length in bits
            nb = lb / blocksize;    // Number of blocks of 512 bits
            if (lb == 0 || lb % blocksize != 0) nb++;
            if ((lb % blocksize) >= (blocksize - lengthsize)) nb++;

            tb = new byte[nb * (blocksize / 8)];
            for (int i = 0; i < lB; i++)
            {
                tb[i] = (byte)s[i];
            }
            int j = lB;
            tb[j++] = 0x80;
            while ((j % (blocksize / 8)) != (blocksize - lengthsize) / 8)
                tb[j++] = 0;
            // Length is always 32-bit in this implementation
            if (lengthsize == 128)
                for (int i = 0; i < 8; i++)
                    tb[j++] = 0;
            tb[j++] = 0;
            tb[j++] = 0;
            tb[j++] = 0;
            tb[j++] = 0;
            tb[j++] = (byte)(lb >> 24);
            tb[j++] = (byte)((lb & 0x00FF0000) >> 16);
            tb[j++] = (byte)((lb & 0x0000FF00) >> 8);
            tb[j++] = (byte)((lb & 0x000000FF));
            Debug.Assert(j % (blocksize / 8) == 0);
            Debug.Assert(j == nb * (blocksize / 8));
        }

        private static string SHA_256(string s)
        {
            // Initialize hash values:
            // First 32 bits of the fractional parts of the square roots of the first 8 primes 2..19:
            // h[0..7]
            uint[] h = {
                0x6a09e667,
                0xbb67ae85,
                0x3c6ef372,
                0xa54ff53a,
                0x510e527f,
                0x9b05688c,
                0x1f83d9ab,
                0x5be0cd19
            };

            return SHA_256_224(s, h);
        }

        private static string SHA_224(string s)
        {
            // Initialize hash values:
            // The second 32 bits of the fractional parts of the square roots of the 9th through 16th primes 23..53:
            // h[0..7]
            uint[] h = {
                0xc1059ed8,
                0x367cd507,
                0x3070dd17,
                0xf70e5939,
                0xffc00b31,
                0x68581511,
                0x64f98fa7,
                0xbefa4fa4
            };

            return SHA_256_224(s, h).Substring(0, 56);
        }

        // Note 1: All variables are 32 bit unsigned integers and addition is calculated modulo 2^32
        // Note 2: For each round, there is one round constant k[i] and one entry in the message schedule array w[i], 0 ≤ i ≤ 63
        // Note 3: The compression function uses 8 working variables, a through h
        // Note 4: Big-endian convention is used when expressing the constants in this pseudocode,
        // and when parsing message block data from bytes to words, for example,
        // the first word of the input message "abc" after padding is 0x61626380
        private static string SHA_256_224(string s, uint[] h)
        {
            // Initialize array of round constants:
            // (first 32 bits of the fractional parts of he cube roots of the first 64 primes 2..311):
            // k[0..63]
            uint[] k = {
                0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
                0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
                0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
                0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
                0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
                0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
                0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
                0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
            };

            // tb: Table of bytes
            // nb: Number of blocks
            Preprocessing(s, 512, 64, out byte[] tb, out int nb);

            // Process the message in successive 512-bit chunks:
            // break message into 512-bit chunks for each chunk

            // br is the bloc rank (number)
            for (int br = 0; br < nb; br++)
            {
                // create a 64-entry message schedule array w[0..63] of 32-bit words
                // (The initial values in w[0..63] don't matter, so many implementations zero them here)
                uint[] w = new uint[64];

                // copy chunk into first 16 words w[0..15] of the message schedule array
                for (int i = 0; i < 64; i += 4)
                    w[i >> 2] = (uint)(tb[(br << 6) + i] << 24) + (uint)(tb[(br << 6) + i + 1] << 16) + (uint)(tb[(br << 6) + i + 2] << 8) + (uint)(tb[(br << 6) + i + 3]);

                // Extend the first 16 words into the remaining 48 words w[16..63] of the message schedule array:
                // for i from 16 to 63
                //      s0 := (w[i-15] rightrotate 7) xor (w[i-15] rightrotate 18) xor (w[i-15] rightshift 3)
                //      s1 := (w[i-2] rightrotate 17) xor (w[i-2] rightrotate 19) xor (w[i-2] rightshift 10)
                //      w[i] := w[i-16] + s0 + w[i-7] + s1
                for (int i = 16; i < 64; i++)
                {
                    uint s0 = RightRotate(w[i - 15], 7) ^ RightRotate(w[i - 15], 18) ^ (w[i - 15] >> 3);
                    uint s1 = RightRotate(w[i - 2], 17) ^ RightRotate(w[i - 2], 19) ^ (w[i - 2] >> 10);
                    w[i] = w[i - 16] + s0 + w[i - 7] + s1;
                }

                // Initialize working variables to current hash value:
                uint a = h[0];
                uint b = h[1];
                uint c = h[2];
                uint d = h[3];
                uint e = h[4];
                uint f = h[5];
                uint g = h[6];
                uint hh = h[7];

                // Compression function main loop:
                // for i from 0 to 63
                for (int i = 0; i < 64; i++)
                {
                    // S1 := (e rightrotate 6) xor (e rightrotate 11) xor (e rightrotate 25)
                    // ch := (e and f) xor ((not e) and g)
                    // temp1 := h + S1 + ch + k[i] + w[i]
                    // S0 := (a rightrotate 2) xor (a rightrotate 13) xor (a rightrotate 22)
                    // maj := (a and b) xor (a and c) xor (b and c)
                    // temp2 := S0 + maj

                    uint S1 = RightRotate(e, 6) ^ RightRotate(e, 11) ^ RightRotate(e, 25);
                    uint ch = (e & f) ^ ((~e) & g);
                    uint temp1 = hh + S1 + ch + k[i] + w[i];
                    uint S0 = RightRotate(a, 2) ^ RightRotate(a, 13) ^ RightRotate(a, 22);
                    uint maj = (a & b) ^ (a & c) ^ (b & c);
                    uint temp2 = S0 + maj;

                    hh = g;
                    g = f;
                    f = e;
                    e = d + temp1;
                    d = c;
                    c = b;
                    b = a;
                    a = temp1 + temp2;
                }

                // Add the compressed chunk to the current hash value:
                h[0] = h[0] + a;
                h[1] = h[1] + b;
                h[2] = h[2] + c;
                h[3] = h[3] + d;
                h[4] = h[4] + e;
                h[5] = h[5] + f;
                h[6] = h[6] + g;
                h[7] = h[7] + hh;
            }

            // Produce the final hash value (big-endian):
            // digest := hash := h[0] append h[1] append h[2] append h[3] append h[4] append h[5] append h[6] append h[7]
            return h[0].ToString("x8") + h[1].ToString("x8") + h[2].ToString("x8") + h[3].ToString("x8") + h[4].ToString("x8") + h[5].ToString("x8") + h[6].ToString("x8") + h[7].ToString("x8");
        }

        private static string SHA_512(string s)
        {
            // Initialize hash values:
            // First 64 bits of the fractional parts of the square roots of the first 8 primes 2..19:
            // h[0..7]
            ulong[] h = {
                0x6a09e667f3bcc908,
                0xbb67ae8584caa73b,
                0x3c6ef372fe94f82b,
                0xa54ff53a5f1d36f1,
                0x510e527fade682d1,
                0x9b05688c2b3e6c1f,
                0x1f83d9abfb41bd6b,
                0x5be0cd19137e2179
            };

            return SHA_512_384(s, h);
        }

        private static string SHA_384(string s)
        {
            // Initialize hash values:
            // First 64 bits of the fractional parts of the square roots of the first 9th to 16th primes:
            // h[0..7]
            ulong[] h = {
                0xcbbb9d5dc1059ed8,
                0x629a292a367cd507,
                0x9159015a3070dd17,
                0x152fecd8f70e5939,
                0x67332667ffc00b31,
                0x8eb44a8768581511,
                0xdb0c2e0d64f98fa7,
                0x47b5481dbefa4fa4
            };

            return SHA_512_384(s, h).Substring(0, 96);
        }

        private static string SHA_512_384(string s, ulong[] h)
        {
            // Initialize array of round constants:
            // First 64 bits of the fractional parts of he cube roots of the first 80 primes 2..409:
            // k[0..79]
            ulong[] k = {
              0x428a2f98d728ae22, 0x7137449123ef65cd, 0xb5c0fbcfec4d3b2f, 0xe9b5dba58189dbbc, 0x3956c25bf348b538,
              0x59f111f1b605d019, 0x923f82a4af194f9b, 0xab1c5ed5da6d8118, 0xd807aa98a3030242, 0x12835b0145706fbe,
              0x243185be4ee4b28c, 0x550c7dc3d5ffb4e2, 0x72be5d74f27b896f, 0x80deb1fe3b1696b1, 0x9bdc06a725c71235,
              0xc19bf174cf692694, 0xe49b69c19ef14ad2, 0xefbe4786384f25e3, 0x0fc19dc68b8cd5b5, 0x240ca1cc77ac9c65,
              0x2de92c6f592b0275, 0x4a7484aa6ea6e483, 0x5cb0a9dcbd41fbd4, 0x76f988da831153b5, 0x983e5152ee66dfab,
              0xa831c66d2db43210, 0xb00327c898fb213f, 0xbf597fc7beef0ee4, 0xc6e00bf33da88fc2, 0xd5a79147930aa725,
              0x06ca6351e003826f, 0x142929670a0e6e70, 0x27b70a8546d22ffc, 0x2e1b21385c26c926, 0x4d2c6dfc5ac42aed,
              0x53380d139d95b3df, 0x650a73548baf63de, 0x766a0abb3c77b2a8, 0x81c2c92e47edaee6, 0x92722c851482353b,
              0xa2bfe8a14cf10364, 0xa81a664bbc423001, 0xc24b8b70d0f89791, 0xc76c51a30654be30, 0xd192e819d6ef5218,
              0xd69906245565a910, 0xf40e35855771202a, 0x106aa07032bbd1b8, 0x19a4c116b8d2d0c8, 0x1e376c085141ab53,
              0x2748774cdf8eeb99, 0x34b0bcb5e19b48a8, 0x391c0cb3c5c95a63, 0x4ed8aa4ae3418acb, 0x5b9cca4f7763e373,
              0x682e6ff3d6b2b8a3, 0x748f82ee5defb2fc, 0x78a5636f43172f60, 0x84c87814a1f0ab72, 0x8cc702081a6439ec,
              0x90befffa23631e28, 0xa4506cebde82bde9, 0xbef9a3f7b2c67915, 0xc67178f2e372532b, 0xca273eceea26619c,
              0xd186b8c721c0c207, 0xeada7dd6cde0eb1e, 0xf57d4f7fee6ed178, 0x06f067aa72176fba, 0x0a637dc5a2c898a6,
              0x113f9804bef90dae, 0x1b710b35131c471b, 0x28db77f523047d84, 0x32caab7b40c72493, 0x3c9ebe0a15c9bebc,
              0x431d67c49c100d4c, 0x4cc5d4becb3e42b6, 0x597f299cfc657e2a, 0x5fcb6fab3ad6faec, 0x6c44198c4a475817
            };

            // Premare message in blocks of 1024 bits (stored in bytes), with a length encoded on 128 bits
            // tb: Table of bytes
            // nb: Number of blocks
            Preprocessing(s, 1024, 128, out byte[] tb, out int nb);

            // Process the message in successive 1024-bit chunks:
            // break message into 1024-bit chunks for each chunk

            // br is the bloc rank (number)
            for (int br = 0; br < nb; br++)
            {
                // create a 80-entry message schedule array w[0..79] of 64-bit words
                // (The initial values in w[0..79] don't matter, so many implementations zero them here)
                ulong[] w = new ulong[80];

                // copy chunk into first 16 long words w[0..15] of the message schedule array
                for (int i = 0; i < 128; i += 8)
                    w[i >> 3] = ((ulong)tb[(br << 7) + i + 0] << 56) + ((ulong)tb[(br << 7) + i + 1] << 48) + ((ulong)tb[(br << 7) + i + 2] << 40) + ((ulong)tb[(br << 7) + i + 3] << 32) +
                                ((ulong)tb[(br << 7) + i + 4] << 24) + ((ulong)tb[(br << 7) + i + 5] << 16) + ((ulong)tb[(br << 7) + i + 6] << 8) + ((ulong)tb[(br << 7) + i + 7]);

                // Extend the first 16 words into the remaining 48 words w[16..63] of the message schedule array:
                // for i from 16 to 79
                //      s0 := (w[i-15] rightrotate 1) xor (w[i-15] rightrotate 8) xor (w[i-15] rightshift 7)
                //      s1 := (w[i-2] rightrotate 19) xor (w[i-2] rightrotate 61) xor (w[i-2] rightshift 6)
                //      w[i] := w[i-16] + s0 + w[i-7] + s1
                for (int i = 16; i < 80; i++)
                {
                    ulong s0 = RightRotate(w[i - 15], 1) ^ RightRotate(w[i - 15], 8) ^ (w[i - 15] >> 7);
                    ulong s1 = RightRotate(w[i - 2], 19) ^ RightRotate(w[i - 2], 61) ^ (w[i - 2] >> 6);
                    w[i] = w[i - 16] + s0 + w[i - 7] + s1;
                }

                // Initialize working variables to current hash value:
                ulong a = h[0];
                ulong b = h[1];
                ulong c = h[2];
                ulong d = h[3];
                ulong e = h[4];
                ulong f = h[5];
                ulong g = h[6];
                ulong hh = h[7];

                // Compression function main loop:
                // 80 rounds for sha512
                for (int i = 0; i < 80; i++)
                {
                    // S1 := (e rightrotate 14) xor (e rightrotate 18) xor (e rightrotate 41)
                    // ch := (e and f) xor ((not e) and g)
                    // temp1 := h + S1 + ch + k[i] + w[i]
                    // S0 := (a rightrotate 28) xor (a rightrotate 34) xor (a rightrotate 39)
                    // maj := (a and b) xor (a and c) xor (b and c)
                    // temp2 := S0 + maj

                    ulong S1 = RightRotate(e, 14) ^ RightRotate(e, 18) ^ RightRotate(e, 41);
                    ulong ch = (e & f) ^ ((~e) & g);
                    ulong temp1 = hh + S1 + ch + k[i] + w[i];
                    ulong S0 = RightRotate(a, 28) ^ RightRotate(a, 34) ^ RightRotate(a, 39);
                    ulong maj = (a & b) ^ (a & c) ^ (b & c);
                    ulong temp2 = S0 + maj;

                    hh = g;
                    g = f;
                    f = e;
                    e = d + temp1;
                    d = c;
                    c = b;
                    b = a;
                    a = temp1 + temp2;
                }

                // Add the compressed chunk to the current hash value:
                h[0] = h[0] + a;
                h[1] = h[1] + b;
                h[2] = h[2] + c;
                h[3] = h[3] + d;
                h[4] = h[4] + e;
                h[5] = h[5] + f;
                h[6] = h[6] + g;
                h[7] = h[7] + hh;
            }

            // Produce the final hash value (big-endian):
            // digest := hash := h0 append h1 append h2 append h3 append h4 append h5 append h6 append h7
            return h[0].ToString("x16") + h[1].ToString("x16") + h[2].ToString("x16") + h[3].ToString("x16") + h[4].ToString("x16") + h[5].ToString("x16") + h[6].ToString("x16") + h[7].ToString("x16");
        }

        // equivalent of C++ _rotr
        // 32-bit version
        private static uint RightRotate(uint original, int bits)
        {
            return (original >> bits) | (original << (32 - bits));
        }

        // 64-bit version
        private static ulong RightRotate(ulong original, int bits)
        {
            return (original >> bits) | (original << (64 - bits));
        }

        /*
        // equivalent of C++ _rotl
        static uint leftrotate(uint original, int bits)
        {
            return (original << bits) | (original >> (32 - bits));
        }
         * */
    }
}