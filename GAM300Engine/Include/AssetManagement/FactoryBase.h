#pragma once
#include "Logger/Logger.h"
#include "ResourceManagement/ResourceRef.h"
#include "GraphicsResource/AssetModel.h"
#include "GraphicsResource/TextureInfo.h"
#include "Identifier/UniqueID.h"
namespace TDS
{
	template <typename T>
	inline constexpr bool wrong_asset_type = false;

	template <typename T>
	class DLL_API AssetFactory
	{
	public:
		AssetFactory()
		{
			static_assert(wrong_asset_type<T>, "AssetFactory is not available for this type");
		}
		//void Preload(ResourceAllocator& resourceMgr);
		//static void Load(std::string_view path, TypeReference<T>& model, ResourceAllocator& resourceMgr);
		void Preload();

		void Load(std::string_view path, TypeReference<T>& model);


	};



}