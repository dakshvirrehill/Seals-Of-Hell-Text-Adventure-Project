#include "Enemy.h"
#include "PlayerManager.h"
#include <iostream>

Enemy::~Enemy()
{
}

void Enemy::initialize()
{
}

void Enemy::update()
{
	if (getLife() > 0 && isInteractable())
	{
		if (!mCanAttack)
		{
			mCanAttack = true;
		}
		else
		{
			std::cout << getName() << std::endl;
			std::cout << getAttackStory() << std::endl;
			PlayerManager::instance().attackPlayer(this);
			mCanAttack = false;
		}
	}
}

void Enemy::attackEnemy(IInteractable* pWeapon)
{
	if (pWeapon != getConditionalObject() && !PlayerManager::instance().hasInInventory)
	{
		IInteractable::attackEnemy(pWeapon);
	}
	else
	{
		getLife() -= 1;
		if (getLife() <= 0)
		{
			enemyDeath();
		}
	}
}

void Enemy::blockAttack()
{
	if(PlayerManager::instance().hasShield())
	{
		std::cout << getName() << std::endl;
		std::cout << getBlockStory() << std::endl;
		PlayerManager::instance().blockAttack();
	}
	else
	{
		IInteractable::blockAttack();
	}
}

void Enemy::enemyDeath()
{
	std::cout << getName() << std::endl;
	std::cout << getDeathStory() << std::endl;
	bool aVal = true;
	for (auto& iter : getConditionUpdateObjects())
	{
		iter->makeInteractable(aVal);
		iter->makeVisible(aVal);
	}
	mCanAttack = false;
	makeInteractable(mCanAttack);
	makeVisible(mCanAttack);
}
