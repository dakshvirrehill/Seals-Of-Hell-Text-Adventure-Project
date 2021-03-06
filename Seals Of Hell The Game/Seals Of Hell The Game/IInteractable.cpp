#include "IInteractable.h"
#include<iostream>
void IInteractable::initialize(bool pIsVisible, bool pIsInteractable)
{
	mVisible = pIsVisible;
	mInteractable = pIsInteractable;
}
void IInteractable::lookObject()
{
	if (mVisible)
	{
		std::cout << getName() << std::endl;
		std::cout << getStory() << std::endl << std::endl;
	}
}
void IInteractable::teleportRegion()
{
	std::cout << getName() << " cannot be used to teleport." << std::endl;
}

void IInteractable::pickObject()
{
	std::cout << getName() << " cannot be used picked up." << std::endl;
}

void IInteractable::goDirection()
{
	std::cout << "Can't Find A Way There." << std::endl;
}

void IInteractable::blockAttack()
{
	std::cout << getName() << " cannot be blocked." << std::endl;
}

void IInteractable::attackEnemy(IInteractable* pWeapon)
{
	std::cout << getName() << " cannot be attacked with "<< pWeapon->getName() << " ."<< std::endl;
}

void IInteractable::wearObject()
{
	std::cout << getName() << " cannot be worn." << std::endl;
}

void IInteractable::playObject()
{
	std::cout << getName() << " cannot be played." << std::endl;
}

void IInteractable::giveObject(IInteractable* pGiveable)
{
	std::cout << pGiveable->getName() << " cannot be given to" << getName() << " ."<< std::endl;
}

void IInteractable::eatObject()
{
	std::cout << getName() << " cannot be eaten." << std::endl;
}

void IInteractable::moveObject()
{
	std::cout << getName() << " cannot be moved." << std::endl;
}

void IInteractable::answerRiddle()
{
	std::cout << getName() << " cannot be answered." << std::endl;
}

void IInteractable::dropObject()
{
	std::cout << getName() << " cannot be dropped." << std::endl;
}

void IInteractable::addCommons(json::JSON& pJSON)
{
	pJSON["mName"] = getName();
	pJSON["mStory"] = getStory();
	pJSON["mIsInteractable"] = mInteractable;
	pJSON["mIsVisible"] = mVisible;
}