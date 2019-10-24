#include "GameLoader.h"
#include "BasicObject.h"
#include "GameManager.h"
#include "PlayerManager.h"
#include "Region.h"
#include "Room.h"
#include "IInteractable.h"
#include "IUpdatable.h"
#include "Collector.h"
#include "Enemy.h"
#include "Gateway.h"
#include "KillZone.h"
#include "OneInteractionItem.h"
#include "PickableItem.h"
#include "Portal.h"
#include<string>
#include <map>
#include <functional>

void GameLoader::initializeBasicObject(json::JSON pData, BasicObject* pObject)
{
	_ASSERT_EXPR(pData.hasKey("mName"), "Data has no name");
	_ASSERT_EXPR(pData.hasKey("mStory"), "Data has no story");
	pObject->initialize(pData["mName"].ToString(), pData["mStory"].ToString());
}

void GameLoader::initializeIInteractable(json::JSON pData, IInteractable* pObject)
{
	_ASSERT_EXPR(pData.hasKey("mVisible"), "Data has no visible bool");
	_ASSERT_EXPR(pData.hasKey("mInteractable"), "Data has no interactable bool");
	initializeBasicObject(pData,pObject);
	pObject->initialize(pData["mVisible"].ToBool(), pData["mInteractable"].ToBool());

}

void GameLoader::initializeIUpdatable(json::JSON pData, IUpdatable* pObject, std::map<std::string,IInteractable*>& pInteractableMap)
{
	_ASSERT_EXPR(pData.hasKey("mAttackStory"), "Data has no attack story");
	_ASSERT_EXPR(pData.hasKey("mDeathStory"), "Data has no death story");
	_ASSERT_EXPR(pData.hasKey("mUpdatableObjects"), "Data has no updatable objects");
	pObject->initialize(pData["mAttackStory"].ToString(), pData["mDeathStory"].ToString());
	for (auto& aUpdatableObj : pData["mUpdatableObjects"].ObjectRange())
	{
		_ASSERT_EXPR(aUpdatableObj.second.hasKey("mClassName"), "Updatable Object can't be created without class name");
		_ASSERT_EXPR(aUpdatableObj.second.hasKey("mObjName"), "Updatable Object can't be created without obj name");
		IInteractable* aUpdatable = nullptr;
		if (pInteractableMap.find(aUpdatableObj.second["mObjName"].ToString()) == pInteractableMap.end())
		{
			aUpdatable = mObjectCreator[aUpdatableObj.second["mClassName"].ToString()](instance());
			pInteractableMap.emplace(aUpdatableObj.second["mObjName"].ToString(), aUpdatable);
		}
		else
		{
			aUpdatable = pInteractableMap[aUpdatableObj.second["mObjName"].ToString()];
		}
		pObject->addConditionUpdateObjects(aUpdatable);
	}
}

IInteractable* GameLoader::CreateCollector() { return new Collector(); }
IInteractable* GameLoader::CreateEnemy() { return new Enemy(); }
IInteractable* GameLoader::CreateKillZone() { return new KillZone(); }
IInteractable* GameLoader::CreateGateway() { return new Gateway(); }
IInteractable* GameLoader::CreateOneInteractionItem() { return new OneInteractionItem(); }
IInteractable* GameLoader::CreatePickableItem() { return new PickableItem(); }
IInteractable* GameLoader::CreatePortal() { return new Portal(); }


void GameLoader::initializeGameFromSave(json::JSON& pGameData)
{

}

void GameLoader::initializeNewGame(json::JSON& pGameData)
{
	_ASSERT_EXPR(pGameData.hasKey("mGameDetails"), "JSON Doesn't have game details");
	_ASSERT_EXPR(pGameData["mGameDetails"].hasKey("mName"), "Game Details has no name");
	_ASSERT_EXPR(pGameData["mGameDetails"].hasKey("mStory"), "Game Details has no story");
	_ASSERT_EXPR(pGameData["mGameDetails"].hasKey("mFirstRegion"), "GameDetails has no first region");
	_ASSERT_EXPR(pGameData["mGameDetails"].hasKey("mRegionDetails"), "JSON Doesn't have region detalis");
	GameManager::instance().BasicObject::initialize(pGameData["mGameDetails"]["mName"].ToString(), pGameData["mGameDetails"]["mStory"].ToString());
	json::JSON aRegions = pGameData["mGameDetails"]["mRegionDetails"];
	//temporary maps for assignment
	std::map<std::string, Region*> aRegionMap;
	std::map<std::string, Room*> aRoomMap;
	std::map<std::string, IInteractable*> aInteractableMap;

	Region* aRegionPtr = new Region();
	aRegionMap.emplace(pGameData["mGameDetails"]["mFirstRegion"].ToString(), aRegionPtr);
	bool aGMInit = false;
	for (auto& aRegion : aRegions.ObjectRange())
	{
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
		initializeBasicObject(aRegion.second, aRegionPtr);
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
		if (!aGMInit)
		{
			if (pGameData["mGameDetails"]["mFirstRegion"].ToString() == aRegion.first)
			{
				GameManager::instance().initialize(aRegionPtr, aEntryRoomPtr);
				aGMInit = true;
			}
		}
		aRegionPtr->initialize(aEntryRoomPtr);
		json::JSON aRooms = aRegion.second["mRooms"];
		for (auto& aRoom : aRooms.ObjectRange())
		{
			Room* aRoomPtr = nullptr;
			if (aRoomMap.find(aRoom.first) == aRoomMap.end())
			{
				aRoomPtr = new Room();
				aRoomMap.emplace(aRoom.first, aRoomPtr);
			}
			else
			{
				aRoomPtr = aRoomMap[aRoom.first];
			}
			initializeBasicObject(aRoom.second, aRoomPtr);
			_ASSERT_EXPR(aRoom.second.hasKey("mHasCollectors"), "Room has no collector bool");
			bool aHasCollector = aRoom.second["mHasCollectors"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mHasEnemies"), "Room has no enemy bool");
			bool aHasEnemy = aRoom.second["mHasEnemies"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mHasKillZones"), "Room has no KillZone bool");
			bool aHasKillZone = aRoom.second["mHasKillZones"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mHasOneInteractionItems"), "Room has no OneInteractionItem bool");
			bool aHasOneInteractionItem = aRoom.second["mHasOneInteractionItems"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mHasPickableItems"), "Room has no PickableItem bool");
			bool aHasPickableItem = aRoom.second["mHasPickableItems"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mHasPortals"), "Room has no PortalItem bool");
			bool aHasPortal = aRoom.second["mHasPortals"].ToBool();
			_ASSERT_EXPR(aRoom.second.hasKey("mGateways"), "Room has no Gateways");
			//figure out gateway logic
			for (auto& aGateway : aRoom.second["mGateways"].ObjectRange())
			{
				_ASSERT_EXPR(aGateway.second.hasKey("mCurrentRoom"), "Gateway has no current room");
				_ASSERT_EXPR(aGateway.second.hasKey("mConnectedRoom"), "Gateway has no connected room");
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
				initializeIInteractable(aGateway.second, aNewGateway);
				Room* aCurRoom = nullptr;
				if (aRoomMap.find(aGateway.second["mCurrentRoom"].ToString()) == aRoomMap.end())
				{
					aCurRoom = new Room();
				}
				else
				{
					aCurRoom = aRoomMap[aGateway.second["mCurrentRoom"].ToString()];
				}
				Room* aConRoom = nullptr;
				if (aRoomMap.find(aGateway.second["mConnectedRoom"].ToString()) == aRoomMap.end())
				{
					aConRoom = new Room();
				}
				else
				{
					aConRoom = aRoomMap[aGateway.second["mConnectedRoom"].ToString()];
				}
				aNewGateway->initialize(aCurRoom, aConRoom);
				aRoomPtr->addInteractable(aInteractableMap[aGateway.first]);
			}
			if (aHasCollector)
			{
				_ASSERT_EXPR(aRoom.second.hasKey("mCollectors"), "Room has no Collectors");
				for (auto& aCollector : aRoom.second["mCollectors"].ObjectRange())
				{
					_ASSERT_EXPR(aCollector.second.hasKey("mGiveableObject"), "Collector has no giveable object");
					Collector* aNewCollector = nullptr;
					if (aInteractableMap.find(aCollector.first) == aInteractableMap.end())
					{
						aNewCollector = new Collector();
						aInteractableMap.emplace(aCollector.first, aNewCollector);
					}
					else
					{
						aNewCollector = (Collector*)aInteractableMap[aCollector.first];
					}
					initializeIInteractable(aCollector.second, aNewCollector);
					initializeIUpdatable(aCollector.second, aNewCollector, aInteractableMap);
					IInteractable* aGiveableObject = nullptr;
					if (aInteractableMap.find(aCollector.second["mGiveableObject"].ToString()) == aInteractableMap.end())
					{
						aGiveableObject = new PickableItem();
						aInteractableMap.emplace(aCollector.second["mGiveableObject"].ToString(), aGiveableObject);
					}
					else
					{
						aGiveableObject = aInteractableMap[aCollector.second["mGiveableObject"].ToString()];
					}
					aNewCollector->setConditionalObject(aGiveableObject);
					aRoomPtr->addInteractable(aInteractableMap[aCollector.first]);
					aRoomPtr->addUpdatable(aNewCollector);
				}
			}
			if (aHasEnemy)
			{
				_ASSERT_EXPR(aRoom.second.hasKey("mEnemies"), "Room has no Enemies");
				for (auto& aEnemy : aRoom.second["mEnemies"].ObjectRange())
				{
					_ASSERT_EXPR(aEnemy.second.hasKey("mLife"), "Enemy has no life");
					_ASSERT_EXPR(aEnemy.second.hasKey("mBlockStory"), "Enemy has no block story");
					_ASSERT_EXPR(aEnemy.second.hasKey("mKillingWeapon"), "Enemy has no killing weapon");
					Enemy* aNewEnemy = nullptr;
					if (aInteractableMap.find(aEnemy.first) == aInteractableMap.end())
					{
						aNewEnemy = new Enemy();
						aInteractableMap.emplace(aEnemy.first, aNewEnemy);
					}
					else
					{
						aNewEnemy = (Enemy*)aInteractableMap[aEnemy.first];
					}
					initializeIInteractable(aEnemy.second, aNewEnemy);
					initializeIUpdatable(aEnemy.second, aNewEnemy, aInteractableMap);
					aNewEnemy->initialize(aEnemy.second["mLife"].ToInt(), aEnemy.second["mBlockStory"].ToString());
					IInteractable* aKillingWeapon = nullptr;
					if (aInteractableMap.find(aEnemy.second["mKillingWeapon"].ToString()) == aInteractableMap.end())
					{
						aKillingWeapon = new PickableItem();
						aInteractableMap.emplace(aEnemy.second["mKillingWeapon"].ToString(), aKillingWeapon);
					}
					else
					{
						aKillingWeapon = aInteractableMap[aEnemy.second["mKillingWeapon"].ToString()];
					}
					aNewEnemy->setConditionalObject(aKillingWeapon);
					aRoomPtr->addInteractable(aInteractableMap[aEnemy.first]);
					aRoomPtr->addUpdatable(aNewEnemy);
				}
			}
			if (aHasKillZone)
			{
				_ASSERT_EXPR(aRoom.second.hasKey("mKillZones"), "Room has no Killzones");
				for (auto& aKillZone : aRoom.second["mKillZones"].ObjectRange())
				{
					_ASSERT_EXPR(aKillZone.second.hasKey("mHasCondition"), "Killzone has no has condition bool");
					bool aHasCond = aKillZone.second["mHasCondition"].ToBool();
					if (aHasCond)
					{
						_ASSERT_EXPR(aKillZone.second.hasKey("mConditionalObject"), "Killzone has no conditional object");
					}
					KillZone* aNewKillZone = nullptr;
					if (aInteractableMap.find(aKillZone.first) == aInteractableMap.end())
					{
						aNewKillZone = new KillZone();
						aInteractableMap.emplace(aKillZone.first, aNewKillZone);
					}
					else
					{
						aNewKillZone = (KillZone*)aInteractableMap[aKillZone.first];
					}
					initializeIInteractable(aKillZone.second, aNewKillZone);
					initializeIUpdatable(aKillZone.second, aNewKillZone, aInteractableMap);
					if (aHasCond)
					{
						IInteractable* aConditionalObject = nullptr;
						if (aInteractableMap.find(aKillZone.second["mConditionalObject"].ToString()) == aInteractableMap.end())
						{
							aConditionalObject = new PickableItem();
							aInteractableMap.emplace(aKillZone.second["mConditionalObject"].ToString(), aConditionalObject);
						}
						else
						{
							aConditionalObject = aInteractableMap[aKillZone.second["mConditionalObject"].ToString()];
						}
						aNewKillZone->setConditionalObject(aConditionalObject);
					}
					else
					{
						aNewKillZone->setConditionalObject(nullptr);
					}
					aRoomPtr->addInteractable(aInteractableMap[aKillZone.first]);
					aRoomPtr->addUpdatable(aNewKillZone);
				}
			}
			if (aHasOneInteractionItem)
			{
				_ASSERT_EXPR(aRoom.second.hasKey("mOneInteractionItems"), "Room has no OneInteractionItems");
				for (auto& aOneInteractionItem : aRoom.second["mOneInteractionItems"].ObjectRange())
				{
					_ASSERT_EXPR(aOneInteractionItem.second.hasKey("mType"), "OneInteractionItem has no trype");
					OneInteractionItem* aNewItem = nullptr;
					if (aInteractableMap.find(aOneInteractionItem.first) == aInteractableMap.end())
					{
						aNewItem = new OneInteractionItem();
						aInteractableMap.emplace(aOneInteractionItem.first, aNewItem);
					}
					else
					{
						aNewItem = (OneInteractionItem*)aInteractableMap[aOneInteractionItem.first];
					}
					initializeIInteractable(aOneInteractionItem.second, aNewItem);
					initializeIUpdatable(aOneInteractionItem.second, aNewItem, aInteractableMap);
					int aType = aOneInteractionItem.second["mType"].ToInt();
					aNewItem->initialize(aType == 0, aType == 1, aType == 2, aType == 3);
					aRoomPtr->addInteractable(aInteractableMap[aOneInteractionItem.first]);
					aRoomPtr->addUpdatable(aNewItem);
				}
			}
			if (aHasPickableItem)
			{
				_ASSERT_EXPR(aRoom.second.hasKey("mPickableItems"), "Room has no Pickable Items");
				for (auto& aPickableItem : aRoom.second["mPickableItems"].ObjectRange())
				{
					_ASSERT_EXPR(aPickableItem.second.hasKey("mType"), "Pickable Item has no type");
					PickableItem* aNewPItem = nullptr;
					if (aInteractableMap.find(aPickableItem.first) == aInteractableMap.end())
					{
						aNewPItem = new PickableItem();
						aInteractableMap.emplace(aPickableItem.first, aNewPItem);
					}
					else
					{
						aNewPItem = (PickableItem*)aInteractableMap[aPickableItem.first];
					}
					initializeIInteractable(aPickableItem.second, aNewPItem);
					int aType = aPickableItem.second["mType"].ToInt();
					if (aPickableItem.second.hasKey("mIsPicked"))
					{
						aNewPItem->initialize(aType == 0, aType == 1, aType == 2, aType == 3, aPickableItem.second["mIsPicked"].ToBool(), aPickableItem.second["mIsWorn"].ToBool(), aPickableItem.second["mIsGiven"].ToBool(), aPickableItem.second["mIsDropped"].ToBool());
					}
					else
					{
						aNewPItem->initialize(aType == 0, aType == 1, aType == 2, aType == 3);
					}
					aRoomPtr->addInteractable(aInteractableMap[aPickableItem.first]);
				}
			}
			if (aHasPortal)
			{
				_ASSERT_EXPR(aRoom.second.hasKey("mPortals"), "Room has no Portals");
				for (auto& aPortal : aRoom.second["mPortals"].ObjectRange())
				{
					_ASSERT_EXPR(aPortal.second.hasKey("mActiveRegion"), "Portal has no active region");
					_ASSERT_EXPR(aPortal.second.hasKey("mConnectedRegion"), "Portal has no connected region");
					Portal* aNewPortal = nullptr;
					if (aInteractableMap.find(aPortal.first) == aInteractableMap.end())
					{
						aNewPortal = new Portal();
						aInteractableMap.emplace(aPortal.first, aNewPortal);
					}
					else
					{
						aNewPortal = (Portal*)aInteractableMap[aPortal.first];
					}
					initializeIInteractable(aPortal.second, aNewPortal);
					Region* aActiveRegion = nullptr;
					if (aRegionMap.find(aPortal.second["mActiveRegion"].ToString()) == aRegionMap.end())
					{
						aActiveRegion = new Region();
						aRegionMap.emplace(aPortal.second["mActiveRegion"].ToString(), aActiveRegion);
					}
					else
					{
						aActiveRegion = aRegionMap[aPortal.second["mActiveRegion"].ToString()];
					}
					Region* aConnectedRegion = nullptr;
					if (aRegionMap.find(aPortal.second["mConnectedRegion"].ToString()) == aRegionMap.end())
					{
						aConnectedRegion = new Region();
						aRegionMap.emplace(aPortal.second["mConnectedRegion"].ToString(), aConnectedRegion);
					}
					else
					{
						aConnectedRegion = aRegionMap[aPortal.second["mConnectedRegion"].ToString()];
					}
					aNewPortal->initialize(aActiveRegion, aConnectedRegion);
					aRoomPtr->addInteractable(aInteractableMap[aPortal.first]);
				}
			}
		}
	}
}
