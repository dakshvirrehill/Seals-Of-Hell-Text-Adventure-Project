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
#include <functional>

///Temp Helper Functions start
IInteractable* CreateCollector() { return new Collector(); }
IInteractable* CreateEnemy() { return new Enemy(); }
IInteractable* CreateKillZone() { return new KillZone(); }
IInteractable* CreateGateway() { return new Gateway(); }
IInteractable* CreateOneInteractionItem() { return new OneInteractionItem(); }
IInteractable* CreatePickableItem() { return new PickableItem(); }
IInteractable* CreatePortal() { return new Portal(); }
//Temp Helper Functions end

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
	mCurrentRegion = aRegionPtr;
	mCurrentRoom = mCurrentRegion->getStartingRoom();
	std::map<std::string, Room*> aRoomMap;
	std::map<std::string, IInteractable*> aInteractableMap;
	//temp function pointer map start
	std::map<std::string, std::function<IInteractable* ()>> aObjectCreator;
	aObjectCreator.emplace("Collector", CreateCollector);
	aObjectCreator.emplace("Enemy", CreateEnemy);
	aObjectCreator.emplace("Gateway", CreateGateway);
	aObjectCreator.emplace("KillZone", CreateKillZone);
	aObjectCreator.emplace("OneInteractionItem", CreateOneInteractionItem);
	aObjectCreator.emplace("PickableItem", CreatePickableItem);
	aObjectCreator.emplace("Portal", CreatePortal);
	//temp function pointer map end
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
			Room* aRoomPtr = nullptr;
			if (aRoomMap.find(aRoom.first) == aRoomMap.end())
			{
				aRoomPtr = new Room();
				aRoomMap.emplace(aRoom.first,aRoomPtr);
			}
			else
			{
				aRoomPtr = aRoomMap[aRoom.first];
			}
			_ASSERT_EXPR(aRoom.second.hasKey("mName"), "Room has no name");
			_ASSERT_EXPR(aRoom.second.hasKey("mStory"), "Room has no story");
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
			aRoomPtr->BasicObject::initialize(aRoom.second["mName"].ToString(), aRoom.second["mStory"].ToString());
			//figure out gateway logic
			for (auto& aGateway : aRoom.second["mGateways"].ObjectRange())
			{
				_ASSERT_EXPR(aGateway.second.hasKey("mName"), "Gateway has no name");
				_ASSERT_EXPR(aGateway.second.hasKey("mStory"), "Gateway has no story");
				_ASSERT_EXPR(aGateway.second.hasKey("mVisible"), "Gateway has no visible bool");
				_ASSERT_EXPR(aGateway.second.hasKey("mInteractable"), "Gateway has no interactable bool");
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
				aNewGateway->BasicObject::initialize(aGateway.second["mName"].ToString(), aGateway.second["mStory"].ToString());
				aNewGateway->IInteractable::initialize(aGateway.second["mVisible"].ToBool(), aGateway.second["mInteractable"].ToBool());
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
					_ASSERT_EXPR(aCollector.second.hasKey("mName"), "Collector has no name");
					_ASSERT_EXPR(aCollector.second.hasKey("mStory"), "Collector has no story");
					_ASSERT_EXPR(aCollector.second.hasKey("mVisible"), "Collector has no visible bool");
					_ASSERT_EXPR(aCollector.second.hasKey("mInteractable"), "Collector has no interactable bool");
					_ASSERT_EXPR(aCollector.second.hasKey("mAttackStory"), "Collector has no attack story");
					_ASSERT_EXPR(aCollector.second.hasKey("mDeathStory"), "Collector has no death story");
					_ASSERT_EXPR(aCollector.second.hasKey("mGiveableObject"), "Collector has no giveable object");
					_ASSERT_EXPR(aCollector.second.hasKey("mUpdatableObjects"), "Collector has no updatable objects");
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
					aNewCollector->BasicObject::initialize(aCollector.second["mName"].ToString(), aCollector.second["mStory"].ToString());
					aNewCollector->IInteractable::initialize(aCollector.second["mVisible"].ToBool(), aCollector.second["mInteractable"].ToBool());
					aNewCollector->IUpdatable::initialize(aCollector.second["mAttackStory"].ToString(), aCollector.second["mDeathStory"].ToString());
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
					for (auto& aUpdatableObj : aCollector.second["mUpdatableObjects"].ObjectRange())
					{
						_ASSERT_EXPR(aUpdatableObj.second.hasKey("mClassName"), "Updatable Object can't be created without class name");
						_ASSERT_EXPR(aUpdatableObj.second.hasKey("mObjName"), "Updatable Object can't be created without obj name");
						IInteractable* aUpdatable = nullptr;
						if (aInteractableMap.find(aUpdatableObj.second["mObjName"].ToString()) == aInteractableMap.end())
						{
							aUpdatable = aObjectCreator[aUpdatableObj.second["mClassName"].ToString()]();
							aInteractableMap.emplace(aUpdatableObj.second["mObjName"].ToString(), aUpdatable);
						}
						else
						{
							aUpdatable = aInteractableMap[aUpdatableObj.second["mObjName"].ToString()];
						}
						aNewCollector->addConditionUpdateObjects(aUpdatable);
					}
					aRoomPtr->addInteractable(aInteractableMap[aCollector.first]);
					aRoomPtr->addUpdatable(aNewCollector);
				}
			}
			if (aHasEnemy)
			{
				_ASSERT_EXPR(aRoom.second.hasKey("mEnemies"), "Room has no Enemies");
				for (auto& aEnemy : aRoom.second["mEnemies"].ObjectRange())
				{
					_ASSERT_EXPR(aEnemy.second.hasKey("mName"), "Enemy has no name");
					_ASSERT_EXPR(aEnemy.second.hasKey("mStory"), "Enemy has no story");
					_ASSERT_EXPR(aEnemy.second.hasKey("mVisible"), "Enemy has no visible bool");
					_ASSERT_EXPR(aEnemy.second.hasKey("mInteractable"), "Enemy has no interactable bool");
					_ASSERT_EXPR(aEnemy.second.hasKey("mAttackStory"), "Enemy has no attack story");
					_ASSERT_EXPR(aEnemy.second.hasKey("mLife"), "Enemy has no life");
					_ASSERT_EXPR(aEnemy.second.hasKey("mBlockStory"), "Enemy has no block story");
					_ASSERT_EXPR(aEnemy.second.hasKey("mDeathStory"), "Enemy has no death story");
					_ASSERT_EXPR(aEnemy.second.hasKey("mKillingWeapon"), "Enemy has no killing weapon");
					_ASSERT_EXPR(aEnemy.second.hasKey("mUpdatableObjects"), "Enemy has no updatable objects");
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
					aNewEnemy->BasicObject::initialize(aEnemy.second["mName"].ToString(), aEnemy.second["mStory"].ToString());
					aNewEnemy->IInteractable::initialize(aEnemy.second["mVisible"].ToBool(), aEnemy.second["mInteractable"].ToBool());
					aNewEnemy->IUpdatable::initialize(aEnemy.second["mAttackStory"].ToString(), aEnemy.second["mDeathStory"].ToString());
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
					for (auto& aUpdatableObj : aEnemy.second["mUpdatableObjects"].ObjectRange())
					{
						_ASSERT_EXPR(aUpdatableObj.second.hasKey("mClassName"), "Updatable Object can't be created without class name");
						_ASSERT_EXPR(aUpdatableObj.second.hasKey("mObjName"), "Updatable Object can't be created without obj name");
						IInteractable* aUpdatable = nullptr;
						if (aInteractableMap.find(aUpdatableObj.second["mObjName"].ToString()) == aInteractableMap.end())
						{
							aUpdatable = aObjectCreator[aUpdatableObj.second["mClassName"].ToString()]();
							aInteractableMap.emplace(aUpdatableObj.second["mObjName"].ToString(), aUpdatable);
						}
						else
						{
							aUpdatable = aInteractableMap[aUpdatableObj.second["mObjName"].ToString()];
						}
						aNewEnemy->addConditionUpdateObjects(aUpdatable);
					}
					aRoomPtr->addInteractable(aInteractableMap[aEnemy.first]);
					aRoomPtr->addUpdatable(aNewEnemy);
				}
			}
			if (aHasKillZone)
			{
				_ASSERT_EXPR(aRoom.second.hasKey("mKillZones"), "Room has no Killzones");
				for (auto& aKillZone : aRoom.second["mKillZones"].ObjectRange())
				{
					_ASSERT_EXPR(aKillZone.second.hasKey("mName"), "Killzone has no name");
					_ASSERT_EXPR(aKillZone.second.hasKey("mStory"), "Killzone has no story");
					_ASSERT_EXPR(aKillZone.second.hasKey("mVisible"), "Killzone has no visible bool");
					_ASSERT_EXPR(aKillZone.second.hasKey("mInteractable"), "Killzone has no interactable bool");
					_ASSERT_EXPR(aKillZone.second.hasKey("mAttackStory"), "Killzone has no attack story");
					_ASSERT_EXPR(aKillZone.second.hasKey("mDeathStory"), "Killzone has no death story");
					_ASSERT_EXPR(aKillZone.second.hasKey("mHasCondition"), "Killzone has no has condition bool");
					_ASSERT_EXPR(aKillZone.second.hasKey("mUpdatableObjects"), "Killzone has no updatable objects");
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
					aNewKillZone->BasicObject::initialize(aKillZone.second["mName"].ToString(), aKillZone.second["mStory"].ToString());
					aNewKillZone->IInteractable::initialize(aKillZone.second["mVisible"].ToBool(), aKillZone.second["mInteractable"].ToBool());
					aNewKillZone->IUpdatable::initialize(aKillZone.second["mAttackStory"].ToString(), aKillZone.second["mDeathStory"].ToString());
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
					for (auto& aUpdatableObj : aKillZone.second["mUpdatableObjects"].ObjectRange())
					{
						_ASSERT_EXPR(aUpdatableObj.second.hasKey("mClassName"), "Updatable Object can't be created without class name");
						_ASSERT_EXPR(aUpdatableObj.second.hasKey("mObjName"), "Updatable Object can't be created without obj name");
						IInteractable* aUpdatable = nullptr;
						if (aInteractableMap.find(aUpdatableObj.second["mObjName"].ToString()) == aInteractableMap.end())
						{
							aUpdatable = aObjectCreator[aUpdatableObj.second["mClassName"].ToString()]();
							aInteractableMap.emplace(aUpdatableObj.second["mObjName"].ToString(), aUpdatable);
						}
						else
						{
							aUpdatable = aInteractableMap[aUpdatableObj.second["mObjName"].ToString()];
						}
						aNewKillZone->addConditionUpdateObjects(aUpdatable);
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
					_ASSERT_EXPR(aOneInteractionItem.second.hasKey("mName"), "OneInteractionItem has no name");
					_ASSERT_EXPR(aOneInteractionItem.second.hasKey("mStory"), "OneInteractionItem has no story");
					_ASSERT_EXPR(aOneInteractionItem.second.hasKey("mVisible"), "OneInteractionItem has no visible bool");
					_ASSERT_EXPR(aOneInteractionItem.second.hasKey("mInteractable"), "OneInteractionItem has no interactable bool");
					_ASSERT_EXPR(aOneInteractionItem.second.hasKey("mAttackStory"), "OneInteractionItem has no attack story");
					_ASSERT_EXPR(aOneInteractionItem.second.hasKey("mDeathStory"), "OneInteractionItem has no death story");
					_ASSERT_EXPR(aOneInteractionItem.second.hasKey("mType"), "OneInteractionItem has no trype");
					_ASSERT_EXPR(aOneInteractionItem.second.hasKey("mUpdatableObjects"), "OneInteractionItem has no updatable objects");
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
					aNewItem->BasicObject::initialize(aOneInteractionItem.second["mName"].ToString(), aOneInteractionItem.second["mStory"].ToString());
					aNewItem->IInteractable::initialize(aOneInteractionItem.second["mVisible"].ToBool(), aOneInteractionItem.second["mInteractable"].ToBool());
					aNewItem->IUpdatable::initialize(aOneInteractionItem.second["mAttackStory"].ToString(), aOneInteractionItem.second["mDeathStory"].ToString());
					int aType = aOneInteractionItem.second["mType"].ToInt();
					aNewItem->initialize(aType == 0, aType == 1, aType == 2, aType == 3);
					for (auto& aUpdatableObj : aOneInteractionItem.second["mUpdatableObjects"].ObjectRange())
					{
						_ASSERT_EXPR(aUpdatableObj.second.hasKey("mClassName"), "Updatable Object can't be created without class name");
						_ASSERT_EXPR(aUpdatableObj.second.hasKey("mObjName"), "Updatable Object can't be created without obj name");
						IInteractable* aUpdatable = nullptr;
						if (aInteractableMap.find(aUpdatableObj.second["mObjName"].ToString()) == aInteractableMap.end())
						{
							aUpdatable = aObjectCreator[aUpdatableObj.second["mClassName"].ToString()]();
							aInteractableMap.emplace(aUpdatableObj.second["mObjName"].ToString(), aUpdatable);
						}
						else
						{
							aUpdatable = aInteractableMap[aUpdatableObj.second["mObjName"].ToString()];
						}
						aNewItem->addConditionUpdateObjects(aUpdatable);
					}
					aRoomPtr->addInteractable(aInteractableMap[aOneInteractionItem.first]);
					aRoomPtr->addUpdatable(aNewItem);
				}
			}
			if (aHasPickableItem)
			{
				_ASSERT_EXPR(aRoom.second.hasKey("mPickableItems"), "Room has no Pickable Items");
				for (auto& aPickableItem : aRoom.second["mPickableItems"].ObjectRange())
				{
					_ASSERT_EXPR(aPickableItem.second.hasKey("mName"), "Pickable Item has no name");
					_ASSERT_EXPR(aPickableItem.second.hasKey("mStory"), "Pickable Item has no story");
					_ASSERT_EXPR(aPickableItem.second.hasKey("mVisible"), "Pickable Item has no visible bool");
					_ASSERT_EXPR(aPickableItem.second.hasKey("mInteractable"), "Pickable Item has no interactable bool");
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
					aNewPItem->BasicObject::initialize(aPickableItem.second["mName"].ToString(), aPickableItem.second["mStory"].ToString());
					aNewPItem->IInteractable::initialize(aPickableItem.second["mVisible"].ToBool(), aPickableItem.second["mInteractable"].ToBool());
					int aType = aPickableItem.second["mType"].ToInt();
					if(aPickableItem.second.hasKey("mIsPicked"))
					{
						aNewPItem->initialize(aType == 0, aType == 1, aType == 2, aType == 3, aPickableItem.second["mIsPicked"].ToBool(),aPickableItem.second["mIsWorn"].ToBool(),aPickableItem.second["mIsGiven"].ToBool(),aPickableItem.second["mIsDropped"].ToBool());
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
					_ASSERT_EXPR(aPortal.second.hasKey("mName"), "Portal has no name");
					_ASSERT_EXPR(aPortal.second.hasKey("mStory"), "Portal has no story");
					_ASSERT_EXPR(aPortal.second.hasKey("mVisible"), "Portal has no visible bool");
					_ASSERT_EXPR(aPortal.second.hasKey("mInteractable"), "Portal has no interactable bool");
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
					aNewPortal->BasicObject::initialize(aPortal.second["mName"].ToString(), aPortal.second["mStory"].ToString());
					aNewPortal->IInteractable::initialize(aPortal.second["mVisible"].ToBool(), aPortal.second["mInteractable"].ToBool());
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
	std::cout << "Type EXIT to exit the game... (The game autosaves on exit and gameover)" << std::endl << std::endl;
	look();
	std::cout << std::endl << "What do you do?" << std::endl << std::endl;
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
