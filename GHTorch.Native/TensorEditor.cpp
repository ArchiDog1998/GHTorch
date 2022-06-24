#include "TensorEditor.h"

namespace TensorEditor
{
	const char* TensorToString(torch::Tensor* tensor) {
		std::string tensor_string = tensor->toString();
		return tensor_string.c_str();

	}

	const char* TensorDescription(torch::Tensor* tensor) {
		std::ostringstream stream;
		stream << *tensor;
		std::string tensor_string = stream.str();
		return tensor_string.c_str();
	}

	torch::Tensor* TensorRand(const int64_t* longarray, int count, bool requiresGrad) {
		return CreateTensor(torch::rand(GetIntArray(longarray, count), torch::requires_grad(requiresGrad)));
	}

	torch::Tensor* TensorZeros(const int64_t* longarray, int count, bool requiresGrad) {
		auto tensor = torch::zeros(GetIntArray(longarray, count), torch::requires_grad(requiresGrad));
		return CreateTensor(tensor);
	}

	torch::Tensor* TensorOnes(const int64_t* longarray, int count, bool requiresGrad) {
		auto tensor = torch::ones(GetIntArray(longarray, count), torch::requires_grad(requiresGrad));
		return CreateTensor(tensor);
	}

	c10::IntArrayRef GetIntArray(const int64_t* longarray, int count) {
		std::initializer_list<int64_t> arr = std::initializer_list<int64_t>(longarray, &(longarray[count]));
		return c10::IntArrayRef(arr);
	}

	torch::Tensor* DuplicateTensor(torch::Tensor* tensor) {
		return new torch::Tensor(*tensor);
	}

	torch::Tensor* ToCudaTensor(torch::Tensor* tensor) {
		if (tensor->is_cuda() || !torch::cuda::is_available())
			return DuplicateTensor(tensor);

		return new torch::Tensor(tensor->cuda());
	}

	torch::Tensor* CreateTensor(const torch::Tensor& tensor) {
		return new torch::Tensor(tensor);
	}


	void DeleteTensor(torch::Tensor* tensor) {
		delete tensor;
	}
}

