#include "GameManager.h"
#include "SaveGameManager.h"
#include<string>
#include "json.hpp"
#include "Region.h"
#include "Room.h"
#include "Collector.h"
#include "Enemy.h"
#include "Gateway.h"
#include "KillZone.h"
#include "OneInteractionItem.h"
#include "PickableItem.h"
#include "Portal.h"

void GameManager::StartGame(std::string& pFileName)
{
	mFileName = pFileName;
	json::JSON aJSONObj = SaveGameManager::instance().loadGame(mFileName);

}
