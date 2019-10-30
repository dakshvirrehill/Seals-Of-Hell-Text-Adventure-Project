#include "CommandManager.h"
#include "PlayerManager.h"
#include "GameManager.h"
#include "IInteractable.h"
#include <iostream>
#include <sstream>
#include <vector>
#include <cctype>
void CommandManager::initialize()
{
	if (!mInitialzed)
	{
		mSingleCommands.emplace("HELP", &CommandManager::help);
		mSingleCommands.emplace("SAVE", &GameManager::saveGame);
		mSingleCommands.emplace("EXIT", &GameManager::endGame);
		mSingleCommands.emplace("INVENTORY", &GameManager::inventory);
		mSingleCommands.emplace("LOOK", &GameManager::look);

		mInteractableCommands.emplace("LOOK", &IInteractable::lookObject);
		mInteractableCommands.emplace("TELEPORT", &IInteractable::teleportRegion);
		mInteractableCommands.emplace("PICK", &IInteractable::pickObject);
		mInteractableCommands.emplace("GO", &IInteractable::goDirection);
		mInteractableCommands.emplace("BLOCK", &IInteractable::blockAttack);
		mInteractableCommands.emplace("WEAR", &IInteractable::wearObject);
		mInteractableCommands.emplace("PLAY", &IInteractable::playObject);
		mInteractableCommands.emplace("EAT", &IInteractable::eatObject);
		mInteractableCommands.emplace("MOVE", &IInteractable::moveObject);
		mInteractableCommands.emplace("ANSWER", &IInteractable::answerRiddle);
		mInteractableCommands.emplace("DROP", &IInteractable::dropObject);

		mTwoInteractionCommands.emplace("GIVE", &IInteractable::giveObject);
		mTwoInteractionCommands.emplace("ATTACK", &IInteractable::attackEnemy);

		mInitialzed = true;
	}
}

void CommandManager::help()
{
	std::cout << "==============================" << std::endl;
	std::cout << "List of Commands" << std::endl;
	std::cout << "HELP" << std::endl;
	std::cout << "SAVE" << std::endl;
	std::cout << "EXIT" << std::endl;
	std::cout << "INVENTORY" << std::endl;
	//std::cout << "WAKE UP" << std::endl;
	std::cout << "LOOK" << std::endl;
	std::cout << "LOOK <Object>" << std::endl;
	std::cout << "TELEPORT <Region>" << std::endl;
	std::cout << "PICK <Object>" << std::endl;
	std::cout << "GO <Direction> (Example: GO North)" << std::endl;
	std::cout << "ATTACK <Enemy> WITH <Weapon>" << std::endl;
	std::cout << "BLOCK <Enemy>" << std::endl;
	std::cout << "WEAR <Object>" << std::endl;
	std::cout << "PLAY <Object>" << std::endl;
	std::cout << "GIVE <Object> TO <Collector>" << std::endl;
	std::cout << "EAT <Object>" << std::endl;
	std::cout << "MOVE <Object>" << std::endl;
	std::cout << "ANSWER <Answer>" << std::endl;
	std::cout << "DROP <Object>" << std::endl;
	//std::cout << "GIVE <Enemy> Love/Hate" << std::endl;
	std::cout << "==============================" << std::endl;
}

std::vector<std::string> CommandManager::getCommandWords(std::string& pCommandStr)
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

void CommandManager::convertToUpper(std::string& pString)
{
	for (size_t aI = 0; aI < pString.size(); aI++)
	{
		if (std::islower(pString[aI]))
		{
			pString[aI] = std::toupper(pString[aI]);
		}
	}
}

bool CommandManager::runCommand(std::string& pCommandStr)
{
	convertToUpper(pCommandStr);
	std::vector<std::string> aCommandWords = getCommandWords(pCommandStr);
	if (aCommandWords.size() <= 0)
	{
		return false;
	}
	if (mSingleCommands.count(pCommandStr) == 1)
	{
		mSingleCommands[pCommandStr]();
		return true;
	}
	bool aTwoInteraction = mTwoInteractionCommands.count(aCommandWords.at(0)) == 1;
	if (mInteractableCommands.count(aCommandWords.at(0)) == 0 
		&& !aTwoInteraction)
	{
		return false;
	}
	std::string aObj1 = "";
	std::string aObj2 = "";
	bool aSInObj2 = false;
	bool aSwapObj1n2 = false;
	//bool aLHF = false;
	for (size_t aI = 1; aI < aCommandWords.size(); aI++)
	{
		if (aCommandWords.at(aI) == "WITH")
		{
			aSInObj2 = true;
			continue;
		}
		else if (aCommandWords.at(aI) == "TO")
		{
			aSInObj2 = true;
			aSwapObj1n2 = true;
			continue;
		}

		if (aSInObj2)
		{
			if (aObj2 != "")
			{
				aObj2 += " ";
			}
			aObj2 += aCommandWords.at(aI);
		}
		else
		{
			if (aObj1 != "")
			{
				aObj1 += " ";
			}
			aObj1 += aCommandWords.at(aI);
		}
	}
	if (aSwapObj1n2) //for implementation sake
	{
		std::string aObJ = aObj1;
		aObj1 = aObj2;
		aObj2 = aObJ;
	}
	IInteractable* aIObj1 = GameManager::instance().getInteractable(aObj1);
	if (aIObj1 == nullptr)
	{
		return false;
	}
	if (aSInObj2)
	{
		IInteractable* aIObj2 = GameManager::instance().getInteractable(aObj2);
		if (aIObj2 == nullptr)
		{
			return false;
		}
		mTwoInteractionCommands[aCommandWords.at(0)](aIObj1, aIObj2);
	}
	else if (aTwoInteraction)
	{
		return false;
	}
	else
	{
		mInteractableCommands[aCommandWords.at(0)](aIObj1);
	}
	return true;
}
