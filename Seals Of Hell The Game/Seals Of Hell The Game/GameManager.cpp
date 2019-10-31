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

void GameManager::look()
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
}

void GameManager::GameLoop()
{
	std::cout << "Welcome to " << getName() << std::endl << std::endl;
	std::cout << getStory() << std::endl << std::endl;
	std::cout << "To interact with the game, type commands..." << std::endl;
	std::cout << "Type HELP to see all the commands..." << std::endl;
	std::cout << "Type SAVE to save the game..." << std::endl;
	std::cout << "Type EXIT to exit the game... (The game autosaves on exit and gameover)" << std::endl << std::endl;
	look();
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
			mCurrentRoom->updateRoom();
		}
		if (mEndGame)
		{
			endGame();
		}
	} while (mGamePlay);
}

void GameManager::setCurrentRegion(Region* pCurrentRegion)
{
	mCurrentRegion = pCurrentRegion;
	mCurrentRoom = mCurrentRegion->getStartingRoom();
	mCurrentRoom->enterRoom();
	look();
}

void GameManager::setCurrentRoom(Room* pRoom)
{
	mCurrentRoom = pRoom;
	mCurrentRoom->enterRoom();
	mCurrentRoom->look();
}

void GameManager::inventory()
{
	GameManager::instance().mCurrentPlayer->inventory();
}

void GameManager::playerWon()
{
	mEndGame = true;
	//Couldn't figure out how to load a completed game
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

void GameManager::endGame()
{
	instance().mGamePlay = false;
	instance().internalSaveGame();
	if (instance().mCurrentPlayer != nullptr)
	{
		delete instance().mCurrentPlayer;
	}
	GameLoader::instance().cleanUpGame(instance().mFirstRegion);
	instance().mCurrentRegion = nullptr;
	instance().mCurrentRoom = nullptr;
	instance().mFirstRegion = nullptr;
	instance().mCurrentPlayer = nullptr;
}

void GameManager::saveGame()
{
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
