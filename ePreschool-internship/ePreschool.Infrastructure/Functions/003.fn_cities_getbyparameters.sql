CREATE OR REPLACE FUNCTION public.fn_cities_getbyparameters("pName" text,"pCountryId" integer)
 RETURNS TABLE("Id" integer, "Name" text, "IsFavorite" bool,"CountryName" text,"CountryId" integer)
 LANGUAGE plpgsql
AS $function$
BEGIN	
	RETURN QUERY 
	SELECT "C"."Id", 
		   "C"."Name",
		   "C"."IsFavorite",
		   "CO"."Name",
		   "C"."CountryId"
	FROM "Cities" AS "C"
	inner join "Countries" as "CO"
	on "CO"."Id"="C"."CountryId"
	WHERE ("pName" IS NULL OR  "C"."Name" ILIKE ('%'||"pName"||'%'))
	AND ("pCountryId"=0 or "pCountryId"="C"."CountryId")
		AND "C"."IsDeleted" = FALSE	
	ORDER BY "C"."IsFavorite" DESC,  "C"."Name" ASC;
END;
$function$
;