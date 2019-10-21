#pragma once
#ifndef ENEMY_H
#define ENEMY_H
#include "IUpdatable.h"
#include "IInteractable.h"
#include <string>
#include <list>
class PickableItem;
class Enemy : public IUpdatable,IInteractable
{
public:
	Enemy() : IUpdatable(), IInteractable() {}
	~Enemy();
	void initialize();
	void update() override;
	void attackEnemy(IInteractable*) override;
	void blockAttack() override;
	void enemyDeath();
};
#endif