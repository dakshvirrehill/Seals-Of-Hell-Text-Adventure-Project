#include "BasicObject.h"
#include "GameManager.h"
#include "SaveGameManager.h"
#include "CommandManager.h"
#include "PlayerManager.h"
#include "json.hpp"
#include "IInteractable.h"
#include "Region.h"
#include "Room.h"
#include "Collector.h"
#include "Enemy.h"
#include "Gateway.h"
#include "KillZone.h"
#include "OneInteractionItem.h"
#include "PickableItem.h"
#include "Portal.h"
#include<string>
#include <map>
void GameManager::look()
{
	if (mCurrentRegion != nullptr)
	{
		mCurrentRegion->look();
	}
	if (mCurrentRoom != nullptr)
	{
		mCurrentRoom->look();
	}
}

void GameManager::StartGame(std::string& pFileName)
{
	mFileName = pFileName;
	json::JSON aJSONObj = SaveGameManager::instance().loadGame(mFileName);
	_ASSERT_EXPR(aJSONObj.hasKey("mGameDetails"), "JSON Doesn't have game details");
	_ASSERT_EXPR(aJSONObj["mGameDetails"].hasKey("mName"), "Game Details has no name");
	_ASSERT_EXPR(aJSONObj["mGameDetails"].hasKey("mStory"), "Game Details has no story");
	_ASSERT_EXPR(aJSONObj["mGameDetails"].hasKey("mFirstRegion"), "GameDetails has no first region");
	_ASSERT_EXPR(aJSONObj["mGameDetails"].hasKey("mRegionDetails"), "JSON Doesn't have region detalis");
	initialize(aJSONObj["mGameDetails"]["mName"].ToString(), aJSONObj["mGameDetails"]["mStory"].ToString());
	json::JSON aRegions = aJSONObj["mGameDetails"]["mRegionDetails"];
	std::map<std::string, Region*> aRegionMap;
	Region* aRegionPtr = new Region();
	aRegionMap.emplace(aJSONObj["mGameDetails"]["mFirstRegion"].ToString(), aRegionPtr);
	std::map<std::string, Room*> aRoomMap;
	std::map<std::string, IInteractable*> aInteractableMap;
	std::map<std::string, IUpdatable*> aUpdatableMap;

	for (auto& aRegion : aRegions.ObjectRange())
	{
		_ASSERT_EXPR(aRegion.second.hasKey("mName"), "Region has no name");
		_ASSERT_EXPR(aRegion.second.hasKey("mStory"), "Region has no story");
		_ASSERT_EXPR(aRegion.second.hasKey("mEntryRoom"), "Region has no entry room");
		_ASSERT_EXPR(aRegion.second.hasKey("mRooms"), "Region has no rooms");
		aRegionPtr = nullptr;
		if (aRegionMap.find(aRegion.first) == aRegionMap.end())
		{
			aRegionPtr = new Region();
			aRegionMap.emplace(aRegion.first, aRegionPtr);
		}
		else
		{
			aRegionPtr = aRegionMap[aRegion.first];
		}
		aRegionPtr->BasicObject::initialize(aRegion.second["mName"].ToString(), aRegion.second["mStory"].ToString());
		Room* aEntryRoomPtr = nullptr;
		if (aRoomMap.find(aRegion.second["mEntryRoom"].ToString()) == aRoomMap.end())
		{
			aEntryRoomPtr = new Room();
			aRoomMap.emplace(aRegion.second["mEntryRoom"].ToString(), aEntryRoomPtr);
		}
		else
		{
			aEntryRoomPtr = aRoomMap[aRegion.second["mEntryRoom"].ToString()];
		}
		aRegionPtr->initialize(aEntryRoomPtr);
		json::JSON aRooms = aRegion.second["mRooms"];
		for (auto& aRoom : aRooms.ObjectRange())
		{
			_ASSERT_EXPR(aRoom.second.hasKey("mName"), "Room has no name");
			_ASSERT_EXPR(aRoom.second.hasKey("mStory"), "Room has no story");
			_ASSERT_EXPR(aRoom.second.hasKey("mHasCollectors"), "Room has no collector bool");
			bool aCollector = aRoom.second["mHasCollectors"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mHasEnemies"), "Room has no enemy bool");
			bool aEnemy = aRoom.second["mHasEnemies"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mHasKillZones"), "Room has no KillZone bool");
			bool aKillZone = aRoom.second["mHasKillZones"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mHasOneInteractionItems"), "Room has no OneInteractionItem bool");
			bool aOneInteractionItem = aRoom.second["mHasOneInteractionItems"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mHasPickableItems"), "Room has no PickableItem bool");
			bool aPickableItem = aRoom.second["mHasPickableItems"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mHasPortals"), "Room has no PortalItem bool");
			bool aPortal = aRoom.second["mHasPortals"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mGateways"), "Room has no Gateways");
			for (auto& aGateway : aRoom.second["mGateways"].ObjectRange())
			{
				_ASSERT_EXPR(aGateway.second.hasKey("mName"), "Gateway has no name");
				_ASSERT_EXPR(aGateway.second.hasKey("mStory"), "Gateway has no story");
				_ASSERT_EXPR(aGateway.second.hasKey("mCurrentRoom"), "Gateway has no current room");
				_ASSERT_EXPR(aGateway.second.hasKey("mConnectedRoom"), "Gateway has no connected room");
				_ASSERT_EXPR(aGateway.second.hasKey("mIsVisible"), "Gateway has no visible bool");
				_ASSERT_EXPR(aGateway.second.hasKey("mIsInteractable"), "Gateway has no interactable bool");
				Gateway* aNewGateway = nullptr;
				if (aInteractableMap.find(aGateway.first) == aInteractableMap.end())
				{
					aNewGateway = new Gateway();
					aInteractableMap.emplace(aGateway.first, aNewGateway);
				}
				else
				{
					aNewGateway = (Gateway*)aInteractableMap[aGateway.first];
				}
			}
		}
	}
	//intialize CommandManager
	CommandManager::instance().initialize();
}

void GameManager::GameLoop()
{
	std::cout << "Welcome to " << getName() << std::endl << std::endl;
	std::cout << getStory() << std::endl << std::endl << std::endl;
	std::cout << "To interact with the game, type commands..." << std::endl;
	std::cout << "Type HELP to see all the commands..." << std::endl;
	std::cout << "Type SAVE to save the game..." << std::endl;
	std::cout << "Type EXIT to exit the game... (The game autosaves on exit and gameover)" << std::endl;
	std::string aCommandStr = "";
	do
	{
		std::getline(std::cin, aCommandStr);
		if (!CommandManager::instance().runCommand(aCommandStr))
		{
			std::cout << std::endl << "The game world did not understand your gibberish... Try again..." << std::endl << std::endl;
		}
		mCurrentRoom->updateRoom();
	} while (mGamePlay);
}

void GameManager::setCurrentRegion(Region* pCurrentRegion)
{
	mCurrentRegion = pCurrentRegion;
	mCurrentRoom = mCurrentRegion->getStartingRoom();
//	mCurrentRoom->enterRoom();
	look();
}

void GameManager::setCurrentRoom(Room* pRoom)
{
	mCurrentRoom = pRoom;
//	mCurrentRoom->enterRoom();
	mCurrentRoom->look();
}


void GameManager::endGame()
{
	mGamePlay = false;
	saveGame();
}

void GameManager::saveGame()
{
	//save game logic
}

IInteractable* GameManager::getInteractable(std::string& pObjName)
{
	IInteractable* aInteractableObj = PlayerManager::instance().getInventoryObject(pObjName);
	if (aInteractableObj == nullptr)
	{
		if (mCurrentRoom != nullptr)
		{
			aInteractableObj = mCurrentRoom->getRoomObject(pObjName);
		}
	}
	return aInteractableObj;
}

void GameManager::removeFromRoom(IInteractable* pInteractable)
{
	mCurrentRoom->removeInteractable(pInteractable);
}

void GameManager::addInRoom(IInteractable* pInteractable)
{
	mCurrentRoom->addInteractable(pInteractable);
}
