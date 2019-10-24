#pragma once
#ifndef ENEMY_H
#define ENEMY_H
#include "IUpdatable.h"
#include "IInteractable.h"
#include <string>
#include <list>
class PickableItem;
class Enemy : public IUpdatable,public IInteractable
{
	bool mCanAttack;
	int mLife;
	std::string mBlockStory;
public:
	Enemy() : IUpdatable(), IInteractable(), mCanAttack(false), mLife(0), mBlockStory("") {}
	~Enemy();
	void initialize(int,std::string);
	void update() override;
	void attackEnemy(IInteractable*) override;
	void blockAttack() override;
	void endUpdate() override;
};
#endif