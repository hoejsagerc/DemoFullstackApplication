import { HourlyForecastResponse } from "@/lib/api/generated-api";
import {
  ChartConfig,
  ChartContainer,
  ChartTooltip,
  ChartTooltipContent,
} from "../ui/chart";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "../ui/card";
import { Area, AreaChart, CartesianGrid, XAxis } from "recharts";
import { TrendingUp } from "lucide-react";

const chartConfig = {
  desktop: {
    label: "Desktop",
    color: "hsl(var(--chart-1))",
  },
} satisfies ChartConfig;

interface Props {
  forecast: HourlyForecastResponse[];
}

export default function HourlyGraph({ forecast }: Props) {
  return (
    <Card className="bg-[#424769] border-0">
      <CardHeader className="mb-4">
        <CardTitle className="text-gray-100">Hourly Forecast</CardTitle>
        <CardDescription className="text-gray-300">
          Displays the weather forecast for the next 5 hours
        </CardDescription>
      </CardHeader>
      <CardContent>
        <ChartContainer config={chartConfig}>
          <AreaChart
            accessibilityLayer
            data={forecast}
            margin={{
              left: 12,
              right: 12,
            }}
          >
            <CartesianGrid vertical={false} />
            <XAxis
              dataKey="date"
              tickLine={false}
              axisLine={false}
              tickMargin={8}
              tickFormatter={(value) => value.slice(0, 3)}
            />
            <ChartTooltip
              cursor={false}
              content={<ChartTooltipContent indicator="line" />}
            />
            <Area
              dataKey="temperatureC"
              type="natural"
              fill="var(--color-desktop)"
              fillOpacity={0.4}
              stroke="var(--color-desktop)"
            />
          </AreaChart>
        </ChartContainer>
      </CardContent>
    </Card>
  );
}
