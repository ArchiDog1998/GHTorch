#include <torch\torch.h>
#include <string>

extern "C" __declspec(dllexport)
const char* Test() {
	torch::Tensor tensor = torch::rand({ 2,3 });
	std::ostringstream stream;
	stream << tensor;
	std::string tensor_string = stream.str();
	return tensor_string.c_str();
}