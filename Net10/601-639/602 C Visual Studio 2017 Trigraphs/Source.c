// 602 CS Trigraphs
// A working example with trigraphs, now that they are officially deprecated in C++17 :-)
// Visual Studio C++ Editor does not seem to accept trigraphs, but compilation is fine
// Spaces are required before ??( for instance
// Can't make digraphs work, such as %: for #
// Compile with option /Zc:trigraphs 
//
// 2016-10-21	PV		First version
// 2017-01-07	PV		Visual Studio 2017 RC and comments.  
//						Also adjusted Windows SDK version to 10.0.14393.0 to get stdio.h from C:\Program Files (x86)\Windows Kits\10\Include\10.0.14393.0\ucrt
// 2021-09-26   PV      VS2022; Net6

#include <stdio.h>

int main() ??<
	printf("What??!\n");		// ??! is a trigraph for |

	int ti ??( 5 ??);			// int ti[5];
	ti ??( 0 ??) = 12 ??! 3;	// ti[0] = 12|3;
	printf("ti??(0??) = %d\n", ti??( 0 ??));

	printf("(pause)\n");
	(void)getchar();
	return 0;
??>
