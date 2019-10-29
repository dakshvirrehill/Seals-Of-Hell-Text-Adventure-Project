#include "Enemy.h"
#include "GameManager.h"
#include <iostream>

Enemy::~Enemy()
{
}

void Enemy::initialize(int pLife, std::string pBlockStory)
{
	mLife = pLife;
	mBlockStory = pBlockStory;
	mCanAttack = true;
}

void Enemy::update()
{
	if (!isInteractable())
	{
		return;
	}
	if (mLife > 0)
	{
		if (!mCanAttack)
		{
			mCanAttack = true;
		}
		else
		{
			std::cout << getName() << std::endl;
			std::cout << getAttackStory() << std::endl;
			bool aVal = false;
			for (auto& iter : getConditionUpdateObjects())
			{
				if (iter->isInteractable())
				{
					iter->makeInteractable(aVal);
				}
				if (iter->isVisible())
				{
					iter->makeVisible(aVal);
				}
			}
			GameManager::instance().attackPlayer(this);
			mCanAttack = false;
		}
	}
}

void Enemy::attackEnemy(IInteractable* pWeapon)
{
	if (pWeapon != getConditionalObject() && !GameManager::instance().hasInInventory(pWeapon))
	{
		IInteractable::attackEnemy(pWeapon);
	}
	else
	{
		mLife -= 1;
		if (mLife <= 0)
		{
			endUpdate();
		}
	}
}

void Enemy::blockAttack()
{
	if(GameManager::instance().hasShield() && mLife > 0)
	{
		std::cout << getName() << std::endl;
		std::cout << mBlockStory << std::endl;
		GameManager::instance().blockAttack();
	}
	else
	{
		IInteractable::blockAttack();
	}
}

void Enemy::endUpdate()
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
