#include<iostream>
#define size 100
using namespace std;

void inPutArray(int a[size][size], int m, int n) {
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cout << "a[" << i << "][" << j << "]= ";
			cin >> a[i][j];
		}
	}

}
void outPutArray(int a[size][size], int m, int n) {
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cout << a[i][j] << "\t";
		}
		cout << endl;
	}
}
void searchMax(int a[size][size], int m, int n) {
	int max = a[0][0];
	int v = 0;
	int t = 0;

	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (a[i][j] > max) {
				max = a[i][j];
				v = i;
				t = j;
			}
		}
	}
	cout << "so lon nhat la   " << max << " o vi tri " << "a[" << v << "][" << t << "] ";
}
void swap(int& x, int& y) {
	int t = x;
	x = y;
	y = t;

}
void sort(int a[size][size], int k, int m, int n) {

	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (a[k - 1][i] < a[k - 1][j]) {
				swap(a[k - 1][i], a[k - 1][j]);
			}
		}
	}
}
int main() {
	int a[size][size];
	int m, n;
	cout << " nhap so dong : ";
	cin >> m;
	cout << " nhap so cot : ";
	cin >> n;
	cout << " nhap cac phan tu cua mang" << endl;
	inPutArray(a, m, n);
	cout << " mang vua nhap la: " << endl;
	outPutArray(a, m, n);
	searchMax(a, m, n);
	int k;
	cout << "nhap k" << endl;
	cin >> k;
	sort(a, k, m, n);
	outPutArray(a, m, n);
	return 0;
}