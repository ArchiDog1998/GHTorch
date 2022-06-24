#pragma once

#include <torch/torch.h>

namespace TensorEditor
{
	extern "C" __declspec(dllexport)
		const char* TensorToString(torch::Tensor * tensor);

	extern "C" __declspec(dllexport)
		const char* TensorDescription(torch::Tensor * tensor);

	extern "C" __declspec(dllexport)
		torch::Tensor * TensorRand(const int64_t * longarray, int count, bool requiresGrad);

	extern "C" __declspec(dllexport)
		torch::Tensor * TensorZeros(const int64_t * longarray, int count, bool requiresGrad);

	extern "C" __declspec(dllexport)
		torch::Tensor * TensorOnes(const int64_t * longarray, int count, bool requiresGrad);

	extern "C" __declspec(dllexport)
		void DeleteTensor(torch::Tensor* tensor);

	extern "C" __declspec(dllexport)
		torch::Tensor * DuplicateTensor(torch::Tensor * tensor);

	extern "C" __declspec(dllexport)
		torch::Tensor * ToCudaTensor(torch::Tensor * tensor);

	c10::IntArrayRef GetIntArray(const int64_t* longarray, int count);

	torch::Tensor* CreateTensor(const torch::Tensor& tensor);
};

