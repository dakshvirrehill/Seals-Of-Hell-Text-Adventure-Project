#include "BasicObject.h"
#include "GameManager.h"
#include "SaveGameManager.h"
#include "CommandManager.h"
#include "json.hpp"
#include "IInteractable.h"
#include "Region.h"
#include "Room.h"
//#include "Collector.h"
//#include "Enemy.h"
//#include "Gateway.h"
//#include "KillZone.h"
//#include "OneInteractionItem.h"
//#include "PickableItem.h"
//#include "Portal.h"
#include<string>
//#include<vector>
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
	_ASSERT_EXPR(aJSONObj.hasKey("mRegionList"), "JSON Doesn't have number of regions");
	aJSONObj = aJSONObj["mRegionList"];
	//convert json and initialize everything
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
//	std::vector<std::string> aCommandWords;
	do
	{
		std:: cin >> aCommandStr;
		if (!CommandManager::instance().runCommand(aCommandStr))
		{
			std::cout << std::endl << "The game world did not understand your gibberish... Try again..." << std::endl << std::endl;
		}
		//aCommandWords = CommandManager::instance().getCommandWords(aCommandStr);
		//if (aCommandWords.size() <= 0)
		//{
		//	continue;
		//}
		//if (aCommandWords.size() == 1)
		//{
		//	
		//}
	} while (mGamePlay);
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
	
}
