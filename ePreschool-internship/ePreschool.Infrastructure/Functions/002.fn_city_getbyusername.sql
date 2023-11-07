CREATE OR REPLACE FUNCTION public.fn_city_getbyusername("pUserName" text)
 RETURNS SETOF "Cities"
 LANGUAGE plpgsql
AS $function$
BEGIN
	RETURN QUERY
	select "C".* from "Cities" as "C"
	inner join "AspNetUsers" as "AU"
	on "AU"."CityId" = "C"."Id" 
	where "AU"."UserName" = "pUserName" and "C"."IsDeleted" =false and "AU"."IsDeleted" =false
	limit 1;
END; 
$function$
;