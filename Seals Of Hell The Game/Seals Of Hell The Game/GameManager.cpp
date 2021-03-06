#include "BasicObject.h"
#include "GameManager.h"
#include "SaveGameManager.h"
#include "CommandManager.h"
#include "PlayerManager.h"
#include "GameLoader.h"
#include "json.hpp"
#include "IInteractable.h"
#include "Region.h"
#include "Room.h"
#include "AnalyticsManager.h"
void GameManager::look()
{
	AnalyticsManager::instance().UpdateActionData("Look");
	instance().internalLook();
}

void GameManager::lookInsideRoom()
{
	mCurrentRoom->look();
}

void GameManager::initialize(Region* pCurrentRegion, Region* pFirstRegion, Room* pCurrentRoom)
{
	mFirstRegion = pFirstRegion;
	mCurrentRegion = pCurrentRegion;
	mCurrentRoom = pCurrentRoom;
}

void GameManager::StartGame(std::string& pFileName, bool& pLoadSave)
{
	mFileName = pFileName + ".json";
	mSaveFileName = pFileName + "_Save.json";
	json::JSON aJSONObj;
	if (mCurrentPlayer == nullptr)
	{
		mCurrentPlayer = new PlayerManager();
	}
	if (!pLoadSave)
	{
		aJSONObj = SaveGameManager::instance().loadGame(mFileName);	
		GameLoader::instance().initializeNewGame(aJSONObj);
	}
	else
	{
		aJSONObj = SaveGameManager::instance().loadGame(mSaveFileName);
		GameLoader::instance().initializeSaveGame(aJSONObj);
	}
	CommandManager::instance().initialize();
	mGamePlay = true;
	mEndGame = false;
	AnalyticsManager::instance().ReInitializeAnalyticsData();
}

void GameManager::GameLoop()
{
	mStartTime = clock();
	std::cout << "Welcome to " << getName() << std::endl << std::endl;
	std::cout << getStory() << std::endl << std::endl;
	std::cout << "To interact with the game, type commands..." << std::endl;
	std::cout << "Type HELP to see all the commands..." << std::endl;
	std::cout << "Type SAVE to save the game..." << std::endl;
	std::cout << "Type EXIT to exit the game... (The game autosaves on exit and gameover)" << std::endl << std::endl;
	internalLook();
	mCurrentRoom->enterRoom();
	std::string aCommandStr = "";
	do
	{
		std::cout << std::endl << "What do you do?" << std::endl << std::endl;
		std::getline(std::cin, aCommandStr);
		if (!CommandManager::instance().runCommand(aCommandStr))
		{
			std::cout << std::endl << "The game world did not understand your gibberish... Try again..." << std::endl << std::endl;
		}
		if (!mEndGame && mGamePlay && mCurrentRoom != nullptr)
		{
			if (mCurrentPlayer->mInAttack)
			{
				mCurrentRoom->updateRoom();
			}
			if (!mEndGame)
			{
				mCurrentRoom->updateRoom();
			}
		}
		if (mEndGame)
		{
			internalEndGame();
		}
	} while (mGamePlay);
}

void GameManager::setCurrentRegion(Region* pCurrentRegion)
{
	mCurrentRegion = pCurrentRegion;
	mCurrentRoom = mCurrentRegion->getStartingRoom();
	mCurrentRoom->enterRoom();
	internalLook();
}

void GameManager::setCurrentRoom(Room* pRoom)
{
	mCurrentRoom = pRoom;
	mCurrentRoom->enterRoom();
	mCurrentRoom->look();
}

void GameManager::inventory()
{
	AnalyticsManager::instance().UpdateActionData("Inventory");
	GameManager::instance().mCurrentPlayer->inventory();
}

void GameManager::playerWon()
{
	mEndGame = true;
}

void GameManager::playerLost()
{
	Room* aPreviousRoom = mCurrentRoom->getPreviousRoom();
	if (aPreviousRoom != nullptr)
	{
		mCurrentPlayer->dropInventory(aPreviousRoom);
		mCurrentRoom->resetIntoRoom();
	}
	else
	{
		mCurrentPlayer->dropInventory(mFirstRegion->getStartingRoom());
	}
	mCurrentPlayer->blockAttack();
	mCurrentRegion = mFirstRegion;
	mCurrentRoom = mFirstRegion->getStartingRoom();
	mCurrentRoom->resetPortals(mFirstRegion);
	mEndGame = true;
}


void GameManager::internalSaveGame()
{
	json::JSON aJSON = json::JSON::Object();
	aJSON["mStateData"] = json::JSON::Object();
	aJSON["mStateData"]["mCurrentRoom"] = mCurrentRoom->getName();
	aJSON["mStateData"]["mPlayerInAttack"] = mCurrentPlayer->mInAttack;
	aJSON["mName"] = getName();
	aJSON["mStory"] = getStory();
	GameLoader::instance().createJSONData(instance().mFirstRegion, aJSON, mCurrentPlayer->getPlayerInventory());
	SaveGameManager::instance().saveGame(aJSON, mSaveFileName);
}

void GameManager::internalEndGame()
{
	clock_t aEndTime = clock();
	GameData* aData = new GameData();
	aData->mGameTimeInSeconds = (double)((aEndTime - mStartTime) / CLOCKS_PER_SEC);
	aData->mNumberofItemsInInventory = mCurrentPlayer->getInventorySize();
	aData->mGameID = -1;
	AnalyticsManager::instance().SetGameData(aData);
	AnalyticsManager::instance().SaveAnalyticsData();
	mGamePlay = false;
	internalSaveGame();
	if (mCurrentPlayer != nullptr)
	{
		delete mCurrentPlayer;
	}
	GameLoader::instance().cleanUpGame(mFirstRegion);
	mCurrentRegion = nullptr;
	mCurrentRoom = nullptr;
	mFirstRegion = nullptr;
	mCurrentPlayer = nullptr;
}

void GameManager::internalLook()
{
	if (instance().mCurrentRegion != nullptr)
	{
		instance().mCurrentRegion->look();
	}
	if (instance().mCurrentRoom != nullptr)
	{
		instance().mCurrentRoom->look();
	}
}

void GameManager::endGame()
{
	AnalyticsManager::instance().UpdateActionData("Exit");
	instance().internalEndGame();
}

void GameManager::saveGame()
{
	AnalyticsManager::instance().UpdateActionData("Save");
	instance().internalSaveGame();
}

IInteractable* GameManager::getInteractable(std::string& pObjName)
{
	IInteractable* aInteractableObj = mCurrentPlayer->getInventoryObject(pObjName);
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
	if (mCurrentRoom != nullptr)
	{
		mCurrentRoom->removeInteractable(pInteractable);
	}
}

void GameManager::addInRoom(IInteractable* pInteractable)
{
	mCurrentRoom->addInteractable(pInteractable);
}

IInteractable* GameManager::getInventoryObject(std::string& pInvObj)
{
	return mCurrentPlayer->getInventoryObject(pInvObj);
}

void GameManager::addInInventory(IInteractable* pInvObj)
{
	mCurrentPlayer->addInInventory(pInvObj);
}

void GameManager::removeFromInventory(IInteractable* pInvObj)
{
	mCurrentPlayer->removeFromInventory(pInvObj);
}

void GameManager::attackPlayer(IInteractable* pEnemy)
{
	mCurrentPlayer->attackPlayer(pEnemy);
}

bool GameManager::isPlayerInAttack()
{
	return mCurrentPlayer->mInAttack;
}

void GameManager::blockAttack()
{
	mCurrentPlayer->blockAttack();
}

bool GameManager::hasShield()
{
	return mCurrentPlayer->hasShield();
}

bool GameManager::hasInInventory(IInteractable* pInvObj)
{
	return mCurrentPlayer->hasInInventory(pInvObj);
}

void GameManager::addNewShield(std::string pShieldName)
{
	mCurrentPlayer->addNewShield(pShieldName);
}

void GameManager::setPlayerInAttack(bool pInAttack)
{
	mCurrentPlayer->mInAttack = pInAttack;
}
