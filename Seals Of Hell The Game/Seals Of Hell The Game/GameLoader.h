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
class GameLoader
{
	std::map<std::string, std::function<IInteractable* ()>> mObjectCreator;
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
	IInteractable* CreateCollector();
	IInteractable* CreateEnemy();
	IInteractable* CreateKillZone();
	IInteractable* CreateGateway();
	IInteractable* CreateOneInteractionItem();
	IInteractable* CreatePickableItem();
	IInteractable* CreatePortal();
protected:
	inline static GameLoader& instance()
	{
		static GameLoader mInstance;
		if (!mInstance.mInit)
		{
			mInstance.mInit = true;
			mInstance.mObjectCreator.emplace("Collector", mInstance.CreateCollector);
			mInstance.mObjectCreator.emplace("Enemy", mInstance.CreateEnemy);
			mInstance.mObjectCreator.emplace("Gateway", mInstance.CreateGateway);
			mInstance.mObjectCreator.emplace("KillZone", mInstance.CreateKillZone);
			mInstance.mObjectCreator.emplace("OneInteractionItem", mInstance.CreateOneInteractionItem);
			mInstance.mObjectCreator.emplace("PickableItem", mInstance.CreatePickableItem);
			mInstance.mObjectCreator.emplace("Portal", mInstance.CreatePortal);
		}
		return mInstance;
	}
	void initializeGameFromSave(json::JSON& pGameData);
	void initializeNewGame(json::JSON& pGameData);
	//think about to json code
	friend class GameManager;
};
#endif