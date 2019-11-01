#include "AnalyticsManager.h"
#include "DatabaseManager.h"

void AnalyticsManager::ReInitializeAnalyticsData()
{
	if (mGameData != nullptr)
	{
		delete mGameData;
	}
	if (mActionData.begin() != mActionData.end())
	{
		auto iter = mActionData.begin();
		while(iter != mActionData.end())
		{
			if ((*iter).second != nullptr)
			{
				delete (*iter).second;
			}
			iter = mActionData.erase(iter);
		}
	}
	if (mPickableData.begin() != mPickableData.end())
	{
		auto iter = mPickableData.begin();
		while (iter != mPickableData.end())
		{
			if ((*iter).second != nullptr)
			{
				delete (*iter).second;
			}
			iter = mPickableData.erase(iter);
		}
	}
	DatabaseManager::instance().getAllData();
}

void AnalyticsManager::SaveAnalyticsData()
{
	if (mGameData != nullptr && mActionData.begin() != mActionData.end() && mPickableData.begin() != mPickableData.end())
	{
		DatabaseManager::instance().setAllData();
	}
}

void AnalyticsManager::UpdateActionData(std::string pActionName)
{
	if (mActionData.count(pActionName) == 1)
	{
		mActionData[pActionName]->mCount++;
	}
	else
	{
		mActionData.emplace(pActionName, new ActionData());
		mActionData[pActionName]->mCommandName = pActionName;
		mActionData[pActionName]->mCount = 1;
		mActionData[pActionName]->mActionId = -1;
	}
}

void AnalyticsManager::SetGameData(GameData* pData)
{
	mGameData = pData;
}

void AnalyticsManager::UpdatePickableData(std::string pPickableName, bool pIsPicked)
{
	if (mPickableData.count(pPickableName) == 1)
	{
		if (pIsPicked)
		{
			mPickableData[pPickableName]->mPickCount++;
		}
		else
		{
			mPickableData[pPickableName]->mDropCount++;
		}
	}
	else
	{
		mPickableData.emplace(pPickableName, new PickableData());
		mPickableData[pPickableName]->mPickableName = pPickableName;
		mPickableData[pPickableName]->mPickCount = 1;
		mPickableData[pPickableName]->mPickableId = -1;
	}
}
