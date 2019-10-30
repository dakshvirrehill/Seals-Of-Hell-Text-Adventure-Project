#pragma once
#ifndef GAME_LOADER_H
#define GAME_LOADER_H
#include "json.hpp"
#include <map>
#include <string>
#include <functional>
class IInteractable;
class BasicObject;
class IUpdatable;
class Room;
class Region;
class GameLoader
{
	std::map<std::string, std::function<IInteractable* (GameLoader&)>> mObjectCreator;
	bool mInit;
	inline explicit GameLoader() :mObjectCreator(),mInit(false) {}
	inline ~GameLoader() {}
	inline explicit GameLoader(GameLoader const&) : mObjectCreator(), mInit(false) {}
	inline GameLoader& operator=(GameLoader const&)
	{
		return *this;
	}
	void initializeBasicObject(json::JSON, BasicObject*);
	void initializeIInteractable(json::JSON, IInteractable*);
	void initializeIUpdatable(json::JSON, IUpdatable*, std::map<std::string,IInteractable*>&);
	void initializeEmptyGateways(Room* pRoom);
	IInteractable* CreateCollector();
	IInteractable* CreateEnemy();
	IInteractable* CreateKillZone();
	IInteractable* CreateGateway();
	IInteractable* CreateOneInteractionItem();
	IInteractable* CreatePickableItem();
	IInteractable* CreatePortal();
	IInteractable* CreateTreasureCollector();
protected:
	inline static GameLoader& instance()
	{
		static GameLoader mInstance;
		if (!mInstance.mInit)
		{
			mInstance.mInit = true;
			mInstance.mObjectCreator.emplace("Collector", &GameLoader::CreateCollector);
			mInstance.mObjectCreator.emplace("Enemy", &GameLoader::CreateEnemy);
			mInstance.mObjectCreator.emplace("Gateway", &GameLoader::CreateGateway);
			mInstance.mObjectCreator.emplace("KillZone", &GameLoader::CreateKillZone);
			mInstance.mObjectCreator.emplace("OneInteractionItem", &GameLoader::CreateOneInteractionItem);
			mInstance.mObjectCreator.emplace("PickableItem", &GameLoader::CreatePickableItem);
			mInstance.mObjectCreator.emplace("Portal", &GameLoader::CreatePortal);
			mInstance.mObjectCreator.emplace("TreasureCollector", &GameLoader::CreateTreasureCollector);
		}
		return mInstance;
	}
	void initializeGameFromSave(json::JSON& pGameData);
	void initializeNewGame(json::JSON& pGameData);
	json::JSON createJSONData(Region*,Room*);
	void cleanUpGame(Region*);
	friend class GameManager;
};
#endif