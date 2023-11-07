CREATE OR REPLACE FUNCTION public.fn_cities_getall()
    RETURNS SETOF "Cities"
    LANGUAGE plpgsql
AS $function$
BEGIN
	RETURN QUERY
	SELECT "C".*
	FROM "Cities" AS "C"
	WHERE "C"."IsDeleted" = false 
	ORDER BY "C"."IsFavorite" DESC,  "C"."Name" ASC;
END; 
$function$;