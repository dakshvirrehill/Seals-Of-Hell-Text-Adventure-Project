#pragma once
#ifndef DATABASE_MANAGER_H
#define DATABASE_MANAGER_H
class sqlite3;
class DatabaseManager
{
	sqlite3* mDBInstance;
	inline explicit DatabaseManager() : mDBInstance(nullptr) {}
	inline ~DatabaseManager() {}
	inline explicit DatabaseManager(DatabaseManager const&) : mDBInstance(nullptr) {}
	inline DatabaseManager& operator=(DatabaseManager const&)
	{
		return *this;
	}
protected:
	inline static DatabaseManager& instance() 
	{
		static DatabaseManager mInstance;
		return mInstance;
	}
	void getAllData();
	void setAllData();
	friend class AnalyticsManager;
};
#endif