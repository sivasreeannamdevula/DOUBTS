
ALTER DATABASE Prac
SET QUERY_STORE = ON (OPERATION_MODE = READ_ONLY)
 
/*To verify the type of mode of query store*/
SELECT * 
FROM sys.database_query_store_options

SELECT TOP 10
    qt.query_sql_text,
    qs.count_executions,
    qs.avg_duration,
    qs.avg_logical_io_reads
FROM sys.query_store_query AS q
JOIN sys.query_store_query_text AS qt ON q.query_text_id = qt.query_text_id
JOIN sys.query_store_runtime_stats AS qs ON q.query_id = qs.runtime_stats_id
ORDER BY qs.count_executions DESC;


SELECT *FROM sys.query_store_query
SELECT *FROM sys.query_store_query_text
SELECT *FROM sys.query_store_runtime_stats
