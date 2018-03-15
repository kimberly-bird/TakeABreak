select 
	CONVERT(VARCHAR(10),Date,101) X,
	sum(d.PointsGoal) PointsGoal, 
	sum(d.PointsEarned), 
	count(d.ProductivityRating)
from
	[Day] d,
	[Break] b,
	BreakType bt
where b.BreakTypeId = bt.BreakTypeId
and d.ProductivityRating > 3 
group by CONVERT(VARCHAR(10),Date,101); 
