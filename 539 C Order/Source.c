// order.c
// find out order of bytes storage in memory
// 2016-06-20   PV

#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>


int main(int argc, char **argv) {
	uint32_t i = 0x12345678;
	uint8_t *p = (uint8_t *)&i;

	printf("p[0]: %02x\n", p[0]);
	printf("p[1]: %02x\n", p[1]);
	printf("p[2]: %02x\n", p[2]);
	printf("p[3]: %02x\n", p[3]);

	FILE *f = fopen("C:\\temp\\f1.bin", "wb");
	fwrite(&i, sizeof(uint32_t), 1, f);
	fclose(f);

	getchar();
	return 0;
}
