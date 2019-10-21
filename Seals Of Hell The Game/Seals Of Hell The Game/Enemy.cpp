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
		std::cout << getName() << std::endl;
		std::cout << getAttackStory() << std::endl;
		PlayerManager::instance().attackPlayer(this);
	}
}

void Enemy::attackEnemy(IInteractable* pWeapon)
{
	if (pWeapon != getConditionalObject())
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
}
