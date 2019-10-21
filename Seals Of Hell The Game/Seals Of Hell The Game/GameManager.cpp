#include "GameManager.h"
#include "SaveGameManager.h"
#include<string>
#include "json.hpp"
#include "Region.h"
#include "Room.h"
//#include "Collector.h"
//#include "Enemy.h"
//#include "Gateway.h"
//#include "KillZone.h"
//#include "OneInteractionItem.h"
//#include "PickableItem.h"
//#include "Portal.h"

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
}

void GameManager::GameLoop()
{

}
