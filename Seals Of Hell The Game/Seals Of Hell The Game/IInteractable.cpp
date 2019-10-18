#include "IInteractable.h"
#include<iostream>
bool IInteractable::teleportRegion()
{
	std::cout << BasicObject::getName() << " cannot be used to teleport." << std::endl;
	return true;
}

bool IInteractable::pickObject()
{
	std::cout << BasicObject::getName() << " cannot be used picked up." << std::endl;
	return true;
}

bool IInteractable::goDirection()
{
	std::cout << "Can't Find A Way There." << std::endl;
	return true;
}

bool IInteractable::blockAttack()
{
	std::cout << BasicObject::getName() << " cannot be used to block attack." << std::endl;
	return true;
}

bool IInteractable::attackEnemy()
{
	std::cout << BasicObject::getName() << " cannot be used to attack enemy." << std::endl;
	return true;
}

bool IInteractable::wearObject()
{
	std::cout << BasicObject::getName() << " cannot be worn." << std::endl;
	return true;
}

bool IInteractable::playObject()
{
	std::cout << BasicObject::getName() << " cannot be played." << std::endl;
	return true;
}

bool IInteractable::giveObject()
{
	std::cout << BasicObject::getName() << " cannot be given." << std::endl;
	return true;
}

bool IInteractable::eatObject()
{
	std::cout << BasicObject::getName() << " cannot be eaten." << std::endl;
	return true;
}

bool IInteractable::moveObject()
{
	std::cout << BasicObject::getName() << " cannot be moved." << std::endl;
	return true;
}

bool IInteractable::answerRiddle()
{
	std::cout << BasicObject::getName() << " cannot be answered." << std::endl;
	return true;
}

bool IInteractable::dropObject()
{
	std::cout << BasicObject::getName() << " cannot be dropped." << std::endl;
	return true;
}
