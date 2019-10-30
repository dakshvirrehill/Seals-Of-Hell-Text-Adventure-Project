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
#include "TreasureCollector.h"
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
	_ASSERT_EXPR(pData.hasKey("mIsVisible"), "Data has no visible bool");
	_ASSERT_EXPR(pData.hasKey("mIsInteractable"), "Data has no interactable bool");
	initializeBasicObject(pData,pObject);
	pObject->initialize(pData["mIsVisible"].ToBool(), pData["mIsInteractable"].ToBool());

}

void GameLoader::initializeIUpdatable(json::JSON pData, IUpdatable* pObject, std::map<std::string,IInteractable*>& pInteractableMap)
{
	_ASSERT_EXPR(pData.hasKey("mUpdateStory"), "Data has no attack story");
	_ASSERT_EXPR(pData.hasKey("mEndStory"), "Data has no death story");
	_ASSERT_EXPR(pData.hasKey("mUpdatableObjectsWithType"), "Data has no updatable objects");
	pObject->initialize(pData["mUpdateStory"].ToString(), pData["mEndStory"].ToString());
	for (auto& aUpdatableObj : pData["mUpdatableObjectsWithType"].ObjectRange())
	{
		IInteractable* aUpdatable = nullptr;
		if (pInteractableMap.count(aUpdatableObj.first) == 0)
		{
			aUpdatable = mObjectCreator[aUpdatableObj.second.ToString()](instance());
			pInteractableMap.emplace(aUpdatableObj.first, aUpdatable);
		}
		else
		{
			aUpdatable = pInteractableMap[aUpdatableObj.first];
		}
		pObject->addConditionUpdateObjects(aUpdatable);
	}
}

void GameLoader::initializeEmptyGateways(Room* pRoom)
{
	Gateway* aGWay = new Gateway();
	aGWay->IInteractable::initialize(false, false);
	aGWay->BasicObject::initialize("", "");
	aGWay->initialize(nullptr, nullptr, false);
	for (int aI = 0; aI <= 3; aI ++)
	{
		for (int aJ = 0; aJ < 2; aJ++)
		{
			pRoom->addGateway(aGWay, aI, aJ);
		}
	}
}

IInteractable* GameLoader::CreateCollector() { return new Collector(); }
IInteractable* GameLoader::CreateEnemy() { return new Enemy(); }
IInteractable* GameLoader::CreateKillZone() { return new KillZone(); }
IInteractable* GameLoader::CreateGateway() { return new Gateway(); }
IInteractable* GameLoader::CreateOneInteractionItem() { return new OneInteractionItem(); }
IInteractable* GameLoader::CreatePickableItem() { return new PickableItem(); }
IInteractable* GameLoader::CreatePortal() { return new Portal(); }
IInteractable* GameLoader::CreateTreasureCollector() { return new TreasureCollector(); }


void GameLoader::initializeGameFromSave(json::JSON& pGameData)
{
	//from save game
}

void GameLoader::initializeNewGame(json::JSON& pGameData)
{
	_ASSERT_EXPR(pGameData.hasKey("mName"), "Game Details has no name");
	_ASSERT_EXPR(pGameData.hasKey("mStory"), "Game Details has no story");
	_ASSERT_EXPR(pGameData.hasKey("mFirstRegion"), "GameDetails has no first region");
	_ASSERT_EXPR(pGameData.hasKey("mRegionDetails"), "JSON Doesn't have region details");
	GameManager::instance().BasicObject::initialize(pGameData["mName"].ToString(), pGameData["mStory"].ToString());
	json::JSON aRegions = pGameData["mRegionDetails"];
	//temporary maps for assignment
	std::map<std::string, Region*> aRegionMap;
	std::map<std::string, Room*> aRoomMap;
	std::map<std::string, IInteractable*> aInteractableMap;

	Region* aRegionPtr = new Region();
	aRegionMap.emplace(pGameData["mFirstRegion"].ToString(), aRegionPtr);
	bool aGMInit = false;
	bool aMakeTreasureCollector = false;
	for (auto& aRegion : aRegions.ObjectRange())
	{
		_ASSERT_EXPR(aRegion.second.hasKey("mEntryRoom"), "Region has no entry room");
		_ASSERT_EXPR(aRegion.second.hasKey("mRooms"), "Region has no rooms");
		aRegionPtr = nullptr;
		if (aRegionMap.count(aRegion.first) == 0)
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
		if (aRoomMap.count(aRegion.second["mEntryRoom"].ToString()) == 0)
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
			if (pGameData["mFirstRegion"].ToString() == aRegion.first)
			{
				GameManager::instance().initialize(aRegionPtr, aEntryRoomPtr);
				aGMInit = true;
				aMakeTreasureCollector = true;
			}
		}
		aRegionPtr->initialize(aEntryRoomPtr);
		json::JSON aRooms = aRegion.second["mRooms"];
		for (auto& aRoom : aRooms.ObjectRange())
		{
			Room* aRoomPtr = nullptr;
			if (aRoomMap.count(aRoom.first) == 0)
			{
				aRoomPtr = new Room();
				aRoomMap.emplace(aRoom.first, aRoomPtr);
			}
			else
			{
				aRoomPtr = aRoomMap[aRoom.first];
			}
			initializeBasicObject(aRoom.second, aRoomPtr);
			initializeEmptyGateways(aRoomPtr);
			if (aRoomPtr == aEntryRoomPtr && aMakeTreasureCollector)
			{
				_ASSERT_EXPR(aRoom.second.hasKey("mTreasureCollector"), "Room has no treasure collector");
				json::JSON aTCol = aRoom.second["mTreasureCollector"];
				_ASSERT_EXPR(aTCol.hasKey("mKey"), "Treasure Collector has no key");
				TreasureCollector* aTCollector = nullptr;
				if (aInteractableMap.count(aTCol["mKey"].ToString()) == 0)
				{
					aTCollector = new TreasureCollector();
					aInteractableMap.emplace(aTCol["mKey"].ToString(), aTCollector);
				}
				else
				{
					aTCollector = (TreasureCollector*)aInteractableMap[aTCol["mKey"].ToString()];
				}
				initializeIInteractable(aTCol, aTCollector);
				initializeIUpdatable(aTCol, aTCollector, aInteractableMap);
				_ASSERT_EXPR(aTCol.hasKey("mTreasures"), "Treasure Collector has no treasures");
				for (auto& aTreasure : aTCol["mTreasures"].ObjectRange())
				{
					PickableItem* aNTreasure = nullptr;
					if (aInteractableMap.count(aTreasure.first) == 0)
					{
						aNTreasure = new PickableItem();
						aInteractableMap.emplace(aTreasure.first, aNTreasure);
					}
					else
					{
						aNTreasure = (PickableItem*)aInteractableMap[aTreasure.first];
					}
					if (aNTreasure->getName() != aTreasure.second.ToString())
					{
						aNTreasure->getName() = aTreasure.second.ToString();
					}
					aTCollector->addTreasures(aNTreasure);
				}
				aMakeTreasureCollector = false;
				aRoomPtr->addInteractable(aTCollector);
			}
			else
			{
				_ASSERT_EXPR(aRoom.second.hasKey("mGateways"), "Room has no Gateways");
				//figure out gateway logic
				for (auto& aGateway : aRoom.second["mGateways"].ObjectRange())
				{
					_ASSERT_EXPR(aGateway.second.hasKey("mRoom1"), "Gateway has no current room");
					_ASSERT_EXPR(aGateway.second.hasKey("mRoom2"), "Gateway has no connected room");
					_ASSERT_EXPR(aGateway.second.hasKey("mPath"), "Gateway has no path");
					Gateway* aNewGateway = nullptr;
					if (aInteractableMap.count(aGateway.first) == 0)
					{
						aNewGateway = new Gateway();
						aInteractableMap.emplace(aGateway.first, aNewGateway);
					}
					else
					{
						aNewGateway = (Gateway*)aInteractableMap[aGateway.first];
					}
					Room* aCurRoom = nullptr;
					if (aRoomMap.count(aGateway.second["mRoom1"].ToString()) == 0)
					{
						aCurRoom = new Room();
						aRoomMap.emplace(aGateway.second["mRoom1"].ToString(), aCurRoom);
					}
					else
					{
						aCurRoom = aRoomMap[aGateway.second["mRoom1"].ToString()];
					}
					if (!aNewGateway->isInitialized())
					{
						Room* aConRoom = nullptr;
						if (aRoomMap.count(aGateway.second["mRoom2"].ToString()) == 0)
						{
							aConRoom = new Room();
							aRoomMap.emplace(aGateway.second["mRoom2"].ToString(), aConRoom);
						}
						else
						{
							aConRoom = aRoomMap[aGateway.second["mRoom2"].ToString()];
						}
						aNewGateway->initialize(aCurRoom, aConRoom, true);
					}
					initializeIInteractable(aGateway.second, aNewGateway);
					aRoomPtr->addGateway(aInteractableMap[aGateway.first],aGateway.second["mPath"].ToInt(),aRoomPtr == aCurRoom ? 0:1);
				}
			}
			if (aRoom.second.hasKey("mCollectors"))
			{
				for (auto& aCollector : aRoom.second["mCollectors"].ObjectRange())
				{
					_ASSERT_EXPR(aCollector.second.hasKey("mConditionalObject"), "Collector has no giveable object");
					Collector* aNewCollector = nullptr;
					if (aInteractableMap.count(aCollector.first) == 0)
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
					if (aInteractableMap.count(aCollector.second["mConditionalObject"].ToString()) == 0)
					{
						aGiveableObject = new PickableItem();
						aInteractableMap.emplace(aCollector.second["mConditionalObject"].ToString(), aGiveableObject);
					}
					else
					{
						aGiveableObject = aInteractableMap[aCollector.second["mConditionalObject"].ToString()];
					}
					aNewCollector->setConditionalObject(aGiveableObject);
					aRoomPtr->addInteractable(aInteractableMap[aCollector.first]);
					aRoomPtr->addUpdatable(aNewCollector);
				}
			}
			if (aRoom.second.hasKey("mEnemies"))
			{
				for (auto& aEnemy : aRoom.second["mEnemies"].ObjectRange())
				{
					_ASSERT_EXPR(aEnemy.second.hasKey("mLife"), "Enemy has no life");
					_ASSERT_EXPR(aEnemy.second.hasKey("mBlockStory"), "Enemy has no block story");
					_ASSERT_EXPR(aEnemy.second.hasKey("mConditionalObject"), "Enemy has no killing weapon");
					Enemy* aNewEnemy = nullptr;
					if (aInteractableMap.count(aEnemy.first) == 0)
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
					if (aInteractableMap.count(aEnemy.second["mConditionalObject"].ToString()) == 0)
					{
						aKillingWeapon = new PickableItem();
						aInteractableMap.emplace(aEnemy.second["mConditionalObject"].ToString(), aKillingWeapon);
					}
					else
					{
						aKillingWeapon = aInteractableMap[aEnemy.second["mConditionalObject"].ToString()];
					}
					aNewEnemy->setConditionalObject(aKillingWeapon);
					aRoomPtr->addInteractable(aInteractableMap[aEnemy.first]);
					aRoomPtr->addUpdatable(aNewEnemy);
				}
			}
			if (aRoom.second.hasKey("mKillZones"))
			{
				for (auto& aKillZone : aRoom.second["mKillZones"].ObjectRange())
				{
					KillZone* aNewKillZone = nullptr;
					if (aInteractableMap.count(aKillZone.first) == 0)
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
					if (aKillZone.second.hasKey("mConditionalObject"))
					{
						IInteractable* aConditionalObject = nullptr;
						if (aInteractableMap.count(aKillZone.second["mConditionalObject"].ToString()) == 0)
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
			if (aRoom.second.hasKey("mOneInteractionItems"))
			{
				for (auto& aOneInteractionItem : aRoom.second["mOneInteractionItems"].ObjectRange())
				{
					_ASSERT_EXPR(aOneInteractionItem.second.hasKey("mType"), "OneInteractionItem has no trype");
					OneInteractionItem* aNewItem = nullptr;
					if (aInteractableMap.count(aOneInteractionItem.first) == 0)
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
			if (aRoom.second.hasKey("mPickableItems"))
			{
				for (auto& aPickableItem : aRoom.second["mPickableItems"].ObjectRange())
				{
					_ASSERT_EXPR(aPickableItem.second.hasKey("mType"), "Pickable Item has no type");
					PickableItem* aNewPItem = nullptr;
					if (aInteractableMap.count(aPickableItem.first) == 0)
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
					if (aType == 1)
					{
						GameManager::instance().addNewShield(aNewPItem->getName());
					}
					aRoomPtr->addInteractable(aInteractableMap[aPickableItem.first]);
				}
			}
			if (aRoom.second.hasKey("mPortals"))
			{
				for (auto& aPortal : aRoom.second["mPortals"].ObjectRange())
				{
					_ASSERT_EXPR(aPortal.second.hasKey("mActiveRegion"), "Portal has no active region");
					_ASSERT_EXPR(aPortal.second.hasKey("mConnectedRegion"), "Portal has no connected region");
					Portal* aNewPortal = nullptr;
					if (aInteractableMap.count(aPortal.first) == 0)
					{
						aNewPortal = new Portal();
						aInteractableMap.emplace(aPortal.first, aNewPortal);
					}
					else
					{
						aNewPortal = (Portal*)aInteractableMap[aPortal.first];
					}
					if (!aNewPortal->isInitialized())
					{
						initializeIInteractable(aPortal.second, aNewPortal);
						Region* aActiveRegion = nullptr;
						if (aRegionMap.count(aPortal.second["mActiveRegion"].ToString()) == 0)
						{
							aActiveRegion = new Region();
							aRegionMap.emplace(aPortal.second["mActiveRegion"].ToString(), aActiveRegion);
						}
						else
						{
							aActiveRegion = aRegionMap[aPortal.second["mActiveRegion"].ToString()];
						}
						Region* aConnectedRegion = nullptr;
						if (aRegionMap.count(aPortal.second["mConnectedRegion"].ToString()) == 0)
						{
							aConnectedRegion = new Region();
							aRegionMap.emplace(aPortal.second["mConnectedRegion"].ToString(), aConnectedRegion);
						}
						else
						{
							aConnectedRegion = aRegionMap[aPortal.second["mConnectedRegion"].ToString()];
						}
						aNewPortal->initialize(aActiveRegion, aConnectedRegion);
					}
					aRoomPtr->addInteractable(aInteractableMap[aPortal.first]);
				}
			}
		}
	}
}

json::JSON GameLoader::createJSONData()
{
	//think about saving
	json::JSON aJSOn;
	return aJSOn;
}
