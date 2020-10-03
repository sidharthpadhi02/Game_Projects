#include <iostream>
#include<math.h>

void primeFactor(int n)
{
    int i;
    while (n%2 == 0){
      cout<<"2\t";
      n = n/2;
   }

    for(i=3;i<=sqrt(n);i=i+2)
    {
        while(n%i==0)
        {
           cout
            n=n/i;
        }
    }
    if(n>2)
    {
        cout<<n
    }
}
void main()
{
    int num;
    cout<<"Enter a number: ";
    cin>>num;

    primeFactor(num);
    return 0;
}
