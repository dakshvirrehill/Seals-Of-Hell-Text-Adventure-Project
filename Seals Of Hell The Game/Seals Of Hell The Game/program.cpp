////////This File Consists of The Main Function////////
#include "GameManager.h"

int main()
{
	std::string mGameFile = "SealsOfHell.json";
	GameManager::instance().StartGame(mGameFile);
	GameManager::instance().GameLoop();
	return 0;
}