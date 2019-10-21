#include "IInteractable.h"
#include<iostream>
void IInteractable::lookObject()
{
	std::cout << BasicObject::getName() << " cannot be looked." << std::endl;
	
}
void IInteractable::teleportRegion()
{
	std::cout << BasicObject::getName() << " cannot be used to teleport." << std::endl;
	
}

void IInteractable::pickObject()
{
	std::cout << BasicObject::getName() << " cannot be used picked up." << std::endl;
	
}

void IInteractable::goDirection()
{
	std::cout << "Can't Find A Way There." << std::endl;
	
}

void IInteractable::blockAttack()
{
	std::cout << BasicObject::getName() << " cannot be used to block attack." << std::endl;
	
}

void IInteractable::attackEnemy(IInteractable* pWeapon)
{
	std::cout << BasicObject::getName() << " cannot be used to attack enemy." << std::endl;
	
}

void IInteractable::wearObject()
{
	std::cout << BasicObject::getName() << " cannot be worn." << std::endl;
	
}

void IInteractable::playObject()
{
	std::cout << BasicObject::getName() << " cannot be played." << std::endl;
	
}

void IInteractable::giveObject(IInteractable* pGiveable)
{
	std::cout << BasicObject::getName() << " cannot be given." << std::endl;
	
}

void IInteractable::eatObject()
{
	std::cout << BasicObject::getName() << " cannot be eaten." << std::endl;
	
}

void IInteractable::moveObject()
{
	std::cout << BasicObject::getName() << " cannot be moved." << std::endl;
	
}

void IInteractable::answerRiddle()
{
	std::cout << BasicObject::getName() << " cannot be answered." << std::endl;
	
}

void IInteractable::dropObject()
{
	std::cout << BasicObject::getName() << " cannot be dropped." << std::endl;
	
}

//void IInteractable::wakeUp()
//{
//	std::cout << BasicObject::getName() << " cannot be woken up." << std::endl;
//	
//}
