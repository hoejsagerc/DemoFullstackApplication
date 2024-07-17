"use client";

import { Client, WeatherForecastResponse } from "@/lib/api/generated-api";
import {
  CloudHailIcon,
  CloudRainIcon,
  CloudRainWindIcon,
  CloudSnowIcon,
  CloudSunIcon,
  SnowflakeIcon,
  Sun,
  SunIcon,
  SunSnowIcon,
} from "lucide-react";
import { useEffect, useState } from "react";
import HourlyGraph from "./hourly-graph";

const iconMap: { [key: string]: React.ElementType } = {
  Sunny: SunIcon,
  SunnySnowy: SunSnowIcon,
  CloudySun: SunSnowIcon,
  CloudySunRainy: CloudSunIcon,
  CloudyHail: CloudHailIcon,
  CloudyRain: CloudRainIcon,
  CloudyRainWind: CloudRainWindIcon,
  CloudySnow: CloudSnowIcon,
  Chill: SnowflakeIcon,
};

const IconMapper = ({ iconName }: { iconName: string }) => {
  const IconComponent = iconMap[iconName];

  if (!IconComponent) {
    return null;
  }

  return <IconComponent />;
};

export default function WeatherForecast() {
  const client = new Client();
  const [isLoading, setIsLoading] = useState(false);
  const [weatherForecast, setWeatherForecast] =
    useState<WeatherForecastResponse | null>(null);

  const fetchWeatherForecast = async () => {
    try {
      setIsLoading(true);
      const response = await client.getWeatherForecast();
      setWeatherForecast(response);
      console.log(response);
    } catch (error) {
      console.error(error);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    fetchWeatherForecast();
  }, []);

  return (
    <div className="my-auto">
      {isLoading && <div>Loading...</div>}
      <div className="grid grid-cols-2 gap-4 border rounded-lg p-10 bg-[#424769]">
        <div className="col-span-1 border-r-2 border-gray-400 pr-4">
          <div className="grid grid-cols-6 gap-2">
            <div className="col-span-3 flex flex-col">
              <h1 className="text-2xl text-gray-200 font-bold upper">
                {weatherForecast?.location}
              </h1>
              <span className="text-6xl font-bold text-gray-100 mt-4">
                {weatherForecast?.todaysForecast?.[1]?.temperatureC ?? ""}°C
              </span>
            </div>

            <div className="col-span-3 flex justify-end items-center">
              <Sun size={150} className="text-yellow-500" />
            </div>

            <div className="col-span-1 flex flex-col justify-center items-center">
              {weatherForecast?.todaysForecast?.map((forecast) => (
                <div
                  key={forecast.hour}
                  className="flex grid-col-2 my-2 pb-4 items-center text-gray-200"
                >
                  <div>
                    <span>{forecast.hour}</span>
                  </div>
                  <div className="flex flex-col justify-center items-center ml-6">
                    <IconMapper iconName={forecast.summary!} />
                    <span className="mt-2">{forecast.temperatureC}°C</span>
                  </div>
                </div>
              ))}
            </div>
            <div className="col-span-5">
              <HourlyGraph forecast={weatherForecast?.todaysForecast!} />
            </div>
          </div>
        </div>
        <div className="col-span-1 pl-4">
          <div className="col-span-6 mt-6">
            <div className="flex-col">
              <h2 className="text-gray-100 font-semibold mb-4 text-2xl">
                Weekly Forecast
              </h2>
              <div className="">
                {weatherForecast?.weeklyForecast?.map((forecast) => (
                  <div
                    key={forecast.date}
                    className="flex grid-col-2 py-4  pl-8 px-4 items-center justify-between text-gray-200"
                  >
                    <div>
                      <span>{forecast.date}</span>
                    </div>
                    <div className="flex flex-col justify-center items-center ml-24">
                      <IconMapper iconName={forecast.summary!} />
                      <span className="mt-2">{forecast.temperatureC}°C</span>
                    </div>
                  </div>
                ))}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
