// CPPCon.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <queue>
struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}
 
};
class Solution {
public:
    std::vector<TreeNode*> splitBST(TreeNode* root, int target) {
        auto head = root;
        auto rv = std::vector<TreeNode*>();
        while (head != nullptr)
        {
        }
        return std::vector<TreeNode*>{root, root};
    }
};

TreeNode* getNode(std::queue<int> q)
{
    TreeNode* rv = new TreeNode(q.front());
    q.pop();
    if (q.front() != -1)
        rv->left = getNode(q);
    q.pop();
    if (q.front() != -1)
        rv->right = getNode(q);
    q.pop();
    return rv;
}

int main()
{
    std::cout << "Hello World!\n";
    auto v = std::vector<int>{ 4, 2, 6, 1, 3, 5, 7 };
    auto q = std::queue<int>();
    for (int n : v)
        q.push(n);
    TreeNode* root = getNode(q);
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
