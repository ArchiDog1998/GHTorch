#include <torch\torch.h>
#include <string>

extern "C" __declspec(dllexport)
const char* Test() {
	torch::Tensor tensor = torch::rand({ 2,3 }).cuda();

}