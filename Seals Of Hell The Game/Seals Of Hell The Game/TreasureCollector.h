#pragma once
#ifndef TREASURE_COLLECTOR_H
#define TREASURE_COLLECTOR_H
#include "IInteractable.h"
#include "IUpdatable.h"
#include <list>

class TreasureCollector : public IInteractable , public IUpdatable
{
	std::list<IInteractable*> mTreasures;
public:
	TreasureCollector() : IInteractable(),IUpdatable(),mTreasures() {}
	~TreasureCollector();
	void update() override;
	void enemyDeath() override;
	void giveObject(IInteractable*) override;
	void addTreasures(IInteractable*);
};
#endif