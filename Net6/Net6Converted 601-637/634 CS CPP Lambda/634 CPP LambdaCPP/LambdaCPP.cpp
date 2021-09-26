// LambdaCPP
// Show that ByRef capture of lambdas can be dangerous in C++
// 
// 2017-09-07	PV
// 2021-09-26   PV      VS2022; Net6

#include <iostream>
#include <vector>
#include <functional>
#include <algorithm>

using namespace std;

using FilterContainer = vector<function<bool(int)>>;

FilterContainer filters;

void addDivisorFilter(int d) {
	auto divisor = min<int>(d, 100);
	filters.emplace_back(
		// If lambda captures by reference, no warning, but local variable is gone when lambda
		// gets executed, so value is anything at this time.  Value capture solves the problem
		[=](int value) {
			return value % divisor == 0;
		});
}

template<typename T>
ostream& operator << (ostream& out, vector<T> v) {
	bool first = true;
	for (const auto& item : v)
		if (first)
		{
			first = false;
			out << '{' << item;
		}
		else
			out << ", " << item;
	out << '}';
	return out;
}

int main() {
	addDivisorFilter(5);
	addDivisorFilter(11);

	vector<int> vi({ 1,2,3,5,7,11,13,17,19 });
	cout << vi << endl;
	vector <int>::iterator new_end = vi.end();
	for (function<bool(int)> predicate : filters)
		new_end = remove_if(vi.begin(), new_end, predicate);
	vi.erase(new_end, vi.end());
	cout << vi << endl;

	cout << "\n(Pause)";
	cin.get();
}