import dynamic from "next/dynamic";

const DynamicWeatherForecast = dynamic(
  () => import("@/components/weatherforecast/weatherforecast"),
  {
    ssr: false,
  }
);

export default function Home() {
  return (
    <div className="flex items-center justify-center h-screen">
      <DynamicWeatherForecast />
    </div>
  );
}
