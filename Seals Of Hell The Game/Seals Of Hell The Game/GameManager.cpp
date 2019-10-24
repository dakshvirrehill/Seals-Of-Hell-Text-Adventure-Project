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

void GameManager::initialize(Region* pCurrentRegion, Room* pCurrentRoom)
{
	mCurrentRegion = pCurrentRegion;
	mCurrentRoom = pCurrentRoom;
}

void GameManager::StartGame(std::string& pFileName)
{
	mFileName = pFileName;
	json::JSON aJSONObj = SaveGameManager::instance().loadGame(mFileName);
	GameLoader::instance().initializeNewGame(aJSONObj);
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
	look();
}

void GameManager::setCurrentRoom(Room* pRoom)
{
	mCurrentRoom = pRoom;
	mCurrentRoom->look();
}

void GameManager::playerWon()
{
	endGame();
	//anything else
}


void GameManager::endGame()
{
	instance().mGamePlay = false;
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
