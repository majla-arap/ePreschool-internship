CREATE OR REPLACE FUNCTION public.fn_workingprograms_getallwithoutdeleted()
    RETURNS SETOF "Programs"
    LANGUAGE plpgsql
AS $function$
BEGIN
	RETURN QUERY
	SELECT "P".*
	FROM "Programs" AS "P"
	WHERE "P"."IsDeleted" = false 
	ORDER BY "P"."Name" ASC;
END; 
$function$;