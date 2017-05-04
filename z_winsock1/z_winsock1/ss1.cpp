#include <WinSock.h>
#include <

int main ()
{
	WSADATA wsaData;

	if ( WSAStartup (MAKEWORD (1,1), &wsaData) != 0 )
	{
		frpintf (stderr, "WSAStartup failed\n");
	}


	return 0;
}