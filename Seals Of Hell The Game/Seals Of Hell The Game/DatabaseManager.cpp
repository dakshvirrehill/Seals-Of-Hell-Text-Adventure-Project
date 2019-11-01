#include "DatabaseManager.h"
#include "AnalyticsManager.h"
#include "sqlite3.h"
#include <iostream>


void DatabaseManager::getAllData()
{
	try
	{
		int aResult = sqlite3_open("SealsOfHell.db", &mDBInstance);
		if (aResult)
		{
			throw - 1;
		}
		sqlite3_stmt* aStatement;
		aResult = sqlite3_prepare_v2(mDBInstance, "SELECT * FROM ActionData", -1, &aStatement, 0);
		if (aResult != SQLITE_OK)
		{
			throw - 1;
		}
		aResult = sqlite3_step(aStatement);
		if (aResult != SQLITE_OK)
		{
			throw - 1;
		}
		while (aResult == SQLITE_ROW)
		{
			ActionData* aNewData = new ActionData();
			aNewData->mActionId = sqlite3_column_int(aStatement, 0);
			aNewData->mCommandName = (const char*) sqlite3_column_text(aStatement, 1);
			aNewData->mCount = sqlite3_column_int(aStatement, 2);
			AnalyticsManager::instance().mActionData.emplace(aNewData->mCommandName, aNewData);
			aResult = sqlite3_step(aStatement);
		}
		aResult = sqlite3_reset(aStatement);
		if (aResult != SQLITE_OK)
		{
			throw - 1;
		}
		aResult = sqlite3_prepare_v2(mDBInstance, "SELECT * FROM PickableData", -1, &aStatement, 0);
		if (aResult != SQLITE_OK)
		{
			throw - 1;
		}
		aResult = sqlite3_step(aStatement);
		if (aResult != SQLITE_OK)
		{
			throw - 1;
		}
		while (aResult == SQLITE_ROW)
		{
			PickableData* aNewData = new PickableData();
			aNewData->mPickableId = sqlite3_column_int(aStatement, 0);
			aNewData->mPickableName = (const char*)sqlite3_column_text(aStatement, 1);
			aNewData->mPickCount = sqlite3_column_int(aStatement, 2);
			aNewData->mDropCount = sqlite3_column_int(aStatement, 2);
			AnalyticsManager::instance().mPickableData.emplace(aNewData->mPickableName, aNewData);
			aResult = sqlite3_step(aStatement);
		}
		aResult = sqlite3_finalize(aStatement);
		if (aResult != SQLITE_OK)
		{
			throw - 1;
		}
		sqlite3_close(mDBInstance);
	}
	catch (...)
	{
		fprintf(stderr, "Can't open database: %s\n", sqlite3_errmsg(mDBInstance));
	}
}

void DatabaseManager::setAllData()
{
	try
	{
		int aResult = sqlite3_open("SealsOfHell.db", &mDBInstance);
		if (aResult)
		{
			throw - 1;
		}
		sqlite3_stmt* aStatement;
		for (auto& iter : AnalyticsManager::instance().mActionData)
		{
			if (iter.second->mActionId != -1)
			{
				aResult = sqlite3_prepare_v2(mDBInstance, "UPDATE ActionData SET Count = ? WHERE ActionId = ?", -1, &aStatement, 0);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
				sqlite3_bind_parameter_count(aStatement);
				aResult = sqlite3_bind_int(aStatement, 1, iter.second->mCount);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
			}
			else
			{
				aResult = sqlite3_prepare_v2(mDBInstance, "INSERT INTO ActionData(CommandName,Count) VALUES(?,?)", -1, &aStatement, 0);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
				sqlite3_bind_parameter_count(aStatement);
				aResult = sqlite3_bind_text(aStatement, 1, iter.second->mCommandName.c_str(), iter.second->mCommandName.size(), SQLITE_STATIC);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
				aResult = sqlite3_bind_int(aStatement, 2, iter.second->mCount);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
			}
			aResult = sqlite3_step(aStatement);
			if (aResult != SQLITE_DONE)
			{
				throw - 1;
			}
			aResult = sqlite3_reset(aStatement);
			if (aResult != SQLITE_OK)
			{
				throw - 1;
			}
		}
		for (auto& iter : AnalyticsManager::instance().mPickableData)
		{
			if (iter.second->mPickableId != -1)
			{
				aResult = sqlite3_prepare_v2(mDBInstance, "UPDATE PickableData SET PickCount = ?, DropCount = ? WHERE PickableId = ?", -1, &aStatement, 0);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
				sqlite3_bind_parameter_count(aStatement);
				aResult = sqlite3_bind_int(aStatement, 1, iter.second->mPickCount);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
				sqlite3_bind_parameter_count(aStatement);
				aResult = sqlite3_bind_int(aStatement, 2, iter.second->mDropCount);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
			}
			else
			{
				aResult = sqlite3_prepare_v2(mDBInstance, "INSERT INTO PickableData(PickableName,PickCount,DropCount) VALUES(?,?,?)", -1, &aStatement, 0);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
				sqlite3_bind_parameter_count(aStatement);
				aResult = sqlite3_bind_text(aStatement, 1, iter.second->mPickableName.c_str(), iter.second->mPickableName.size(), SQLITE_STATIC);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
				aResult = sqlite3_bind_int(aStatement, 2, iter.second->mPickCount);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
				aResult = sqlite3_bind_int(aStatement, 3, iter.second->mDropCount);
				if (aResult != SQLITE_OK)
				{
					throw - 1;
				}
			}
			aResult = sqlite3_step(aStatement);
			if (aResult != SQLITE_DONE)
			{
				throw - 1;
			}
			aResult = sqlite3_reset(aStatement);
			if (aResult != SQLITE_OK)
			{
				throw - 1;
			}
		}
		aResult = sqlite3_prepare_v2(mDBInstance, "INSERT INTO GameData(GameTime,InventoryCount) VALUES(?,?)", -1, &aStatement, 0);
		if (aResult != SQLITE_OK)
		{
			throw - 1;
		}
		sqlite3_bind_parameter_count(aStatement);
		aResult = sqlite3_bind_double(aStatement, 1, AnalyticsManager::instance().mGameData->mGameTimeInSeconds);
		if (aResult != SQLITE_OK)
		{
			throw - 1;
		}
		aResult = sqlite3_bind_int(aStatement, 2, AnalyticsManager::instance().mGameData->mNumberofItemsInInventory);
		if (aResult != SQLITE_OK)
		{
			throw - 1;
		}
		aResult = sqlite3_step(aStatement);
		if (aResult != SQLITE_DONE)
		{
			throw - 1;
		}
		sqlite3_finalize(aStatement);
		sqlite3_close(mDBInstance);
	}
	catch (...)
	{
		fprintf(stderr, "Can't open database: %s\n", sqlite3_errmsg(mDBInstance));
	}
}
