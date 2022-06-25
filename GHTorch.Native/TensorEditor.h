#pragma once

#include <torch/torch.h>

namespace TensorEditor
{

#pragma region Create
	extern "C" __declspec(dllexport)
		torch::Tensor * TensorValue(const int64_t * longarray, int count, char* value,
			int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

	extern "C" __declspec(dllexport)
		torch::Tensor * TensorEmpty(const int64_t * longarray, int count,
			int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

	extern "C" __declspec(dllexport)
		torch::Tensor * TensorRandom(const int64_t * longarray, int count, bool normal,
			int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

	extern "C" __declspec(dllexport)
		torch::Tensor * TensorRandomInt(const int64_t * longarray, int count, int64_t low, int64_t high,
			int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

	extern "C" __declspec(dllexport)
		torch::Tensor * TensorSpace(char* start, char* end, int64_t step, bool isLog,
			int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

	extern "C" __declspec(dllexport)
		torch::Tensor * TensorArange(char* start, char* end, char* step,
			int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

	extern "C" __declspec(dllexport)
		torch::Tensor * TensorEye(int64_t n, int64_t m,
			int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

	extern "C" __declspec(dllexport)
		torch::Tensor * TensorPerm(int64_t n,
			int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

	extern "C" __declspec(dllexport)
		torch::Tensor * DuplicateTensor(torch::Tensor * tensor);

	torch::Tensor* CreateTensor(const torch::Tensor& tensor);
#pragma endregion


#pragma region Delete
	extern "C" __declspec(dllexport)
		void DeleteTensor(torch::Tensor * tensor);

#pragma endregion

#pragma region Check
	extern "C" __declspec(dllexport)
		const char* TensorDescription(torch::Tensor * tensor);

	extern "C" __declspec(dllexport)
		const char* TensorRequiresGrad(torch::Tensor * tensor, std::string *&stringInt);

	extern "C" __declspec(dllexport)
		const char* TensorDataType(torch::Tensor * tensor, std::string * &stringInt);

	extern "C" __declspec(dllexport)
		const char* TensorDevice(torch::Tensor * tensor, std::string * &stringInt);

	extern "C" __declspec(dllexport)
		const char* TensorLayout(torch::Tensor * tensor, std::string * &stringInt);

	extern "C" __declspec(dllexport)
		void DeleteString(std::string * boolInt);

#pragma endregion




	c10::IntArrayRef GetIntArray(const int64_t* longarray, int count);


	torch::TensorOptions CreateTensorOptions(int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

	bool GetScalar(char* value, int dtype, c10::Scalar& scalar);
};

