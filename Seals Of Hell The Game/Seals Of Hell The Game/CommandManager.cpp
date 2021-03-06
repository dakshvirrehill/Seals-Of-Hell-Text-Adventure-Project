#include "CommandManager.h"
#include "PlayerManager.h"
#include "GameManager.h"
#include "IInteractable.h"
#include "AnalyticsManager.h"
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
	AnalyticsManager::instance().UpdateActionData("Help");
	std::cout << "==============================" << std::endl;
	std::cout << "List of Commands" << std::endl;
	std::cout << "HELP" << std::endl;
	std::cout << "SAVE" << std::endl;
	std::cout << "EXIT" << std::endl;
	std::cout << "INVENTORY" << std::endl;
	std::cout << "LOOK" << std::endl;
	std::cout << "LOOK <Object Name>" << std::endl;
	std::cout << "TELEPORT <Portal Name>" << std::endl;
	std::cout << "PICK <Object Name>" << std::endl;
	std::cout << "GO <Direction> (Example: GO North)" << std::endl;
	std::cout << "ATTACK <Enemy Name> WITH <Weapon Name>" << std::endl;
	std::cout << "BLOCK <Enemy Name>" << std::endl;
	std::cout << "WEAR <Object Name>" << std::endl;
	std::cout << "PLAY <Object Name>" << std::endl;
	std::cout << "GIVE <Object Name> TO <Collector Name>" << std::endl;
	std::cout << "EAT <Object Name>" << std::endl;
	std::cout << "MOVE <Object Name>" << std::endl;
	std::cout << "ANSWER <Answer Name>" << std::endl;
	std::cout << "DROP <Object Name>" << std::endl;
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
	if (pString.size() > 0)
	{
		if (pString[0] == ' ')
		{
			pString = pString.substr(1);
		}
	}
	if (pString.size() > 0)
	{
		if (pString[pString.size() - 1] == ' ')
		{
			pString = pString.substr(0, pString.size() - 1);
		}
	}
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
	for (size_t aI = 1; aI < aCommandWords.size(); aI++)
	{
		if (aTwoInteraction && aCommandWords.at(aI) == "WITH")
		{
			aSInObj2 = true;
			continue;
		}
		else if (aTwoInteraction && aCommandWords.at(aI) == "TO")
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
		if (aCommandWords.at(0) == "LOOK")
		{
			AnalyticsManager::instance().UpdateActionData("Look");
		}
	}
	return true;
}
