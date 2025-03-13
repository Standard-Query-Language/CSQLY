# CSQLY Query Syntax

CSQLY uses YAML for writing SQL queries in a more structured and readable format. This document explains the syntax and features available for writing queries.

## Basic Query Structure

CSQLY queries are structured based on the type of SQL operation you want to perform:

### SELECT Queries

```yaml
select:
  columns:
    - column1
    - column2
    - alias: column3
  from: tableName
  where:
    condition1: value1
    condition2: value2
  orderBy:
    - field: column1
      direction: asc
  limit: 10
  offset: 20
```

### INSERT Queries

```yaml
insert:
  into: tableName
  values:
    - column1: value1
      column2: value2
    - column1: value3
      column2: value4
```

### UPDATE Queries

```yaml
update:
  table: tableName
  set:
    column1: newValue1
    column2: newValue2
  where:
    condition: value
```

### DELETE Queries

```yaml
delete:
  from: tableName
  where:
    condition: value
```

## Condition Operators

CSQLY supports various condition operators:

### Simple Equality

```yaml
where:
  column: value  # Equivalent to column = value
```

### Comparison Operators

```yaml
where:
  column:
    $gt: 10      # Greater than (>)
    $gte: 10     # Greater than or equal (>=)
    $lt: 20      # Less than (<)
    $lte: 20     # Less than or equal (<=)
    $ne: 30      # Not equal (<>)
    $like: "%pattern%"  # LIKE operator
```

### Logical Operators

```yaml
where:
  $and:          # AND operator
    - column1: value1
    - column2: value2

  $or:           # OR operator
    - column1: value1
    - column2: value2

  $not:          # NOT operator
    column: value
```

### IN Operator

```yaml
where:
  column:
    $in: [1, 2, 3]  # IN (1, 2, 3)
```

### BETWEEN Operator

```yaml
where:
  column:
    $between: [10, 20]  # BETWEEN 10 AND 20
```

### IS NULL / IS NOT NULL

```yaml
where:
  column:
    $isNull: true    # IS NULL
    $isNotNull: true # IS NOT NULL
```

## Joins

```yaml
select:
  columns:
    - t1.column1
    - t2.column2
  from: table1 AS t1
  joins:
    - type: inner      # inner, left, right, full
      table: table2 AS t2
      on:
        t1.id: t2.id
```

## Aggregation Functions

```yaml
select:
  columns:
    - count: "*"       # COUNT(*)
    - sum: amount      # SUM(amount)
    - avg: price       # AVG(price)
    - min: value       # MIN(value)
    - max: value       # MAX(value)
  from: tableName
  groupBy:
    - category
  having:
    count:
      $gt: 5           # HAVING COUNT(*) > 5
```

## Subqueries

```yaml
select:
  columns:
    - name
  from: employees
  where:
    department_id:
      $in:
        select:        # Subquery
          columns:
            - id
          from: departments
          where:
            location: "New York"
```

## Parameters

Parameters can be used for values that might change between query executions:

```yaml
select:
  columns:
    - name
    - email
  from: users
  where:
    role: $role         # Parameter named "role"
    created_at:
      $gt: $startDate   # Parameter named "startDate"
```

These parameters will be replaced with properly escaped values when the query is executed.

## Advanced Features

### Common Table Expressions (CTEs)

```yaml
with:
  cte_name:
    select:
      columns:
        - id
        - amount
      from: orders
      where:
        status: "completed"
select:
  columns:
    - customer_name
    - total_amount
  from: customers c
  joins:
    - type: inner
      table: cte_name o
      on:
        c.id: o.customer_id
```

### Window Functions

```yaml
select:
  columns:
    - name
    - department
    - salary
    - rank:
        over:
          partitionBy:
            - department
          orderBy:
            - field: salary
              direction: desc
  from: employees
```

## Best Practices

1. Use consistent indentation for readability
2. Use parameters instead of hardcoding values
3. Split complex queries into smaller, more manageable parts
4. Add comments where necessary to explain the purpose of specific conditions
5. Test your queries on smaller datasets before running on production data
