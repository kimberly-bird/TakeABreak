select d.ProductivityRating, d.Date, d.PointsEarned, d.PointsGoal, b.Length, bt.Type
from "Day" d,
	"Break" b,
	BreakType bt
where d.DayId = b.DayId
order by d.ProductivityRating desc

