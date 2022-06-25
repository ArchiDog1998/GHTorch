// GHTorch.Console.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <torch/torch.h>
#include <iostream>

int main()
{ 
    torch::Tensor tensor = torch::rand({ 3,4 });
    std::cout << tensor << std::endl;
    at::indexing::TensorIndex ind = at::indexing::TensorIndex(1);
    at::indexing::TensorIndex ind2 = at::indexing::TensorIndex(1);
    //std::initializer_list<at::indexing::TensorIndex> arr = 
    //    std::initializer_list<at::indexing::TensorIndex>()
    std::cout << tensor.index({ torch::indexing::Slice(1, torch::indexing::None, 2), 1}) << std::endl;

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
