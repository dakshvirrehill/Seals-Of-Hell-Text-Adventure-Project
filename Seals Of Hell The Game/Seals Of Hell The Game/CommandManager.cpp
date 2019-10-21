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
	mSingleCommands.emplace("HELP", CommandManager::instance().help);
	mSingleCommands.emplace("SAVE", GameManager::instance().saveGame);
	mSingleCommands.emplace("EXIT", GameManager::instance().endGame);
	mSingleCommands.emplace("INVENTORY", PlayerManager::instance().inventory);
	mSingleCommands.emplace("LOOK", GameManager::instance().look);
	mSingleCommands.emplace("WAKE UP", PlayerManager::instance().wakeUp);

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
	mInteractableCommands.emplace("GIVE LOVE", &IInteractable::giveLove);
	mInteractableCommands.emplace("GIVE HATE", &IInteractable::giveHate);

	mTwoInteractionCommands.emplace("GIVE", &IInteractable::giveObject);
	mTwoInteractionCommands.emplace("ATTACK", &IInteractable::attackEnemy);

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
	std::cout << "WAKE UP" << std::endl;
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
	std::cout << "GIVE <Enemy> Love/Hate" << std::endl;
	std::cout << "==============================" << std::endl;
}

//std::function<bool(IInteractable*)> CommandManager::getInteractableCommandPointer(std::string& pCommandVerb)
//{
//	if (mInteractableCommands.find(pCommandVerb) == mInteractableCommands.end())
//	{
//		return nullptr;
//	}
//	return mInteractableCommands[pCommandVerb];
//}
//
//std::function<void()> CommandManager::getSingleCommandPointer(std::string& pCommandVerb)
//{
//	if (mSingleCommands.find(pCommandVerb) == mSingleCommands.end())
//	{
//		return nullptr;
//	}
//	return mSingleCommands[pCommandVerb];
//}

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

void CommandManager::convertToUpper(std::string& pString)
{
	for (int aI = 0; aI < pString.size(); aI++)
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
	if (mSingleCommands.find(pCommandStr) != mSingleCommands.end())
	{
		mSingleCommands[pCommandStr]();
		return true;
	}
	if (mInteractableCommands.find(aCommandWords.at(0)) == mInteractableCommands.end() 
		|| mTwoInteractionCommands.find(aCommandWords.at(0)) == mTwoInteractionCommands.end())
	{
		return false;
	}
	std::string aObj1 = "";
	std::string aObj2 = "";
	bool aSInObj2 = false;
	bool aLHF = false;
	for (int aI = 1; aI < aCommandWords.size(); aI++)
	{
		if (aCommandWords.at(aI) == "WITH" || aCommandWords.at(aI) == "TO")
		{
			aSInObj2 = true;
			continue;
		}
		else if (aCommandWords.at(aI) == "LOVE" || aCommandWords.at(aI) == "HATE")
		{
			aLHF = true;
			aSInObj2 = true;
		}
		if (aSInObj2)
		{
			aObj2 += " " + aCommandWords.at(aI);
		}
		else
		{
			aObj1 += " " + aCommandWords.at(aI);
		}
	}
	IInteractable* aIObj1 = GameManager::instance().getInteractable(aObj1);
	if (aIObj1 == nullptr)
	{
		return false;
	}
	if (aSInObj2)
	{
		if (aLHF)
		{
			aObj2 = aCommandWords.at(0) + " " + aObj2;
			if (mInteractableCommands.find(aObj2) == mInteractableCommands.end())
			{
				return false;
			}
			mInteractableCommands[aObj2](aIObj1);
		}
		IInteractable* aIObj2 = GameManager::instance().getInteractable(aObj2);
		if (aIObj2 == nullptr)
		{
			return false;
		}
		mTwoInteractionCommands[aCommandWords.at(0)](aIObj1, aIObj2);
	}
	else
	{
		mInteractableCommands[aCommandWords.at(0)](aIObj1);
	}
	return true;
}
