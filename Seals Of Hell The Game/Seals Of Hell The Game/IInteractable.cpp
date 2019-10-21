#include "IInteractable.h"
#include<iostream>
bool IInteractable::lookObject()
{
	std::cout << BasicObject::getName() << " cannot be looked." << std::endl;
	return false;
}
bool IInteractable::teleportRegion()
{
	std::cout << BasicObject::getName() << " cannot be used to teleport." << std::endl;
	return false;
}

bool IInteractable::pickObject()
{
	std::cout << BasicObject::getName() << " cannot be used picked up." << std::endl;
	return false;
}

bool IInteractable::goDirection()
{
	std::cout << "Can't Find A Way There." << std::endl;
	return false;
}

bool IInteractable::blockAttack()
{
	std::cout << BasicObject::getName() << " cannot be used to block attack." << std::endl;
	return false;
}

bool IInteractable::attackEnemy(IInteractable* pWeapon)
{
	std::cout << BasicObject::getName() << " cannot be used to attack enemy." << std::endl;
	return false;
}

bool IInteractable::wearObject()
{
	std::cout << BasicObject::getName() << " cannot be worn." << std::endl;
	return false;
}

bool IInteractable::playObject()
{
	std::cout << BasicObject::getName() << " cannot be played." << std::endl;
	return false;
}

bool IInteractable::giveObject(IInteractable* pGiveable)
{
	std::cout << BasicObject::getName() << " cannot be given." << std::endl;
	return false;
}

bool IInteractable::eatObject()
{
	std::cout << BasicObject::getName() << " cannot be eaten." << std::endl;
	return false;
}

bool IInteractable::moveObject()
{
	std::cout << BasicObject::getName() << " cannot be moved." << std::endl;
	return false;
}

bool IInteractable::answerRiddle()
{
	std::cout << BasicObject::getName() << " cannot be answered." << std::endl;
	return false;
}

bool IInteractable::dropObject()
{
	std::cout << BasicObject::getName() << " cannot be dropped." << std::endl;
	return false;
}

//bool IInteractable::wakeUp()
//{
//	std::cout << BasicObject::getName() << " cannot be woken up." << std::endl;
//	return false;
//}
