////////This File Consists of The Main Function////////
#include "GameManager.h"
#include <iostream>

int main()
{
	std::string aGameFile = "SealsOfHell";
	bool aLoadGame = false;
	int aChoice = 0;
	while(true)
	{
		std::cout << "<<<<<GAME MENU>>>>>" << std::endl;
		std::cout << "1. NEW GAME" << std::endl;
		std::cout << "2. LOAD GAME" << std::endl;
		std::cout << "Press Any Other Key for EXIT GAME" << std::endl;
		std::cout << "Enter Choice..." << std::endl;
		std::cout << ">>";
		std::cin >> aChoice;
		if (aChoice == 1)
		{
			aLoadGame = false;
		}
		else if (aChoice == 2)
		{
			aLoadGame = true;
		}
		else
		{
			break;
		}
		GameManager::instance().StartGame(aGameFile, aLoadGame);
		GameManager::instance().GameLoop();
	}
	return 0;
}