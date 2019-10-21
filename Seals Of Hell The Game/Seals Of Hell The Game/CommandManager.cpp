#include "CommandManager.h"
#include "PlayerManager.h"
#include "GameManager.h"
#include "IInteractable.h"
#include <iostream>
#include <sstream>
#include <vector>
void CommandManager::initialize()
{
	mSingleCommands.emplace("HELP", CommandManager::instance().help);
	mSingleCommands.emplace("SAVE", GameManager::instance().SaveGame);
	mSingleCommands.emplace("EXIT", GameManager::instance().EndGame);
	mSingleCommands.emplace("INVENTORY", PlayerManager::instance().inventory);
	mSingleCommands.emplace("LOOK", GameManager::instance().look);

	mInteractableCommands.emplace("LOOK", &IInteractable::lookObject);
	mInteractableCommands.emplace("TELEPORT", &IInteractable::teleportRegion);
	mInteractableCommands.emplace("PICK", &IInteractable::pickObject);
	mInteractableCommands.emplace("GO", &IInteractable::goDirection);
	mInteractableCommands.emplace("ATTACK", &IInteractable::attackEnemy);
	mInteractableCommands.emplace("WEAR", &IInteractable::wearObject);
	mInteractableCommands.emplace("PLAY", &IInteractable::playObject);
	mInteractableCommands.emplace("GIVE", &IInteractable::giveObject);
	mInteractableCommands.emplace("EAT", &IInteractable::eatObject);
	mInteractableCommands.emplace("MOVE", &IInteractable::moveObject);
	mInteractableCommands.emplace("ANSWER", &IInteractable::answerRiddle);
	mInteractableCommands.emplace("DROP", &IInteractable::dropObject);
	mInteractableCommands.emplace("GIVE", &IInteractable::giveObject);
	mInteractableCommands.emplace("WAKE", &IInteractable::wakeUp);
	mInitialzed = true;
}

void CommandManager::help()
{
	std::cout << "==============================" << std::endl;
	std::cout << "List of Commands" << std::endl;
	std::cout << "HELP" << std::endl;
	std::cout << "SAVE" << std::endl;
	std::cout << "EXIT" << std::endl;
	std::cout << "INVENTORY" << std::endl;
	std::cout << "LOOK" << std::endl;
	std::cout << "LOOK <Object>" << std::endl;
	std::cout << "TELEPORT <Region>" << std::endl;
	std::cout << "PICK <Object>" << std::endl;
	std::cout << "GO <Direction> (Example: GO North)" << std::endl;
	std::cout << "ATTACK <Enemy> WITH <Weapon>" << std::endl;
	std::cout << "WEAR <Object>" << std::endl;
	std::cout << "PLAY <Object>" << std::endl;
	std::cout << "GIVE <Object>" << std::endl;
	std::cout << "EAT <Object>" << std::endl;
	std::cout << "MOVE <Object>" << std::endl;
	std::cout << "ANSWER <Answer>" << std::endl;
	std::cout << "DROP <Object>" << std::endl;
	std::cout << "GIVE <Enemy> Love/Hate" << std::endl;
	std::cout << "WAKE Up" << std::endl;
	std::cout << "==============================" << std::endl;
}

std::function<bool(IInteractable*)> CommandManager::getInteractableCommandPointer(std::string& pCommandVerb)
{
	if (mInteractableCommands.find(pCommandVerb) == mInteractableCommands.end())
	{
		return nullptr;
	}
	return mInteractableCommands[pCommandVerb];
}

std::function<void()> CommandManager::getSingleCommandPointer(std::string& pCommandVerb)
{
	if (mSingleCommands.find(pCommandVerb) == mSingleCommands.end())
	{
		return nullptr;
	}
	return mSingleCommands[pCommandVerb];
}

std::vector<std::string>& CommandManager::getCommandWords(std::string& pCommandStr)
{
	std::vector<std::string> aCommandVector;
	std::istringstream aCommandStream(pCommandStr);
	std::string aWord("");
	while (aCommandStream >> aWord)
	{
		aCommandVector.push_back(aWord);
	}
	return aCommandVector;
}
